using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelProject.DAL;
using HotelProject.Models;

namespace HotelProject.Controllers
{
    public class ImageHotelsController : Controller
    {
        public int UploadImageInDataBase(HttpPostedFileBase file, ImageHotel imageHotel)
        {
            imageHotel.Image = ConvertToBytes(file);
            var Content = new ImageHotel
            {
                Image = imageHotel.Image,
                HotelID = imageHotel.HotelID

            };
            db.HotelImages.Add(Content);
            int i = db.SaveChanges();
            if (i == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
        public ActionResult RetrieveImage(int id)
        {
            byte[] cover = GetImageFromDataBase(id);
            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
        }
        public byte[] GetImageFromDataBase(int Id)
        {
            var q = from temp in db.HotelImages where temp.ID == Id select temp.Image;
            byte[] cover = q.First();
            return cover;
        }
        private HotelContext db = new HotelContext();

        // GET: ImageHotels
        public ActionResult Index()
        {
            var hotelImages = db.HotelImages.Include(i => i.Hotel);
            return View(hotelImages.ToList());
        }
        public ActionResult HotelImage()
        {
            var hotelImages = db.HotelImages.Include(i => i.Hotel);
            return View(hotelImages.ToList());
        }

        // GET: ImageHotels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageHotel imageHotel = db.HotelImages.Find(id);
            if (imageHotel == null)
            {
                return HttpNotFound();
            }
            return View(imageHotel);
        }

        // GET: ImageHotels/Create
        public ActionResult Create()
        {
            ViewBag.HotelID = new SelectList(db.Hotels, "ID", "Name");
            return View();
        }

        // POST: ImageHotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,HotelID")] ImageHotel imageHotel)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];
            ImageHotelsController service = new ImageHotelsController();
            int i = service.UploadImageInDataBase(file, imageHotel);
            if (i == 1 && ModelState.IsValid)
            {
                db.HotelImages.Add(imageHotel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.RoomId = new SelectList(db.Room, "ID", "Name", imageHotel.HotelID);
            return View(imageHotel);
            /* if (ModelState.IsValid)
             {
                 db.HotelImages.Add(imageHotel);
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }

             ViewBag.HotelID = new SelectList(db.Hotels, "ID", "Name", imageHotel.HotelID);
             return View(imageHotel);*/
        }

        // GET: ImageHotels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageHotel imageHotel = db.HotelImages.Find(id);
            if (imageHotel == null)
            {
                return HttpNotFound();
            }
            ViewBag.HotelID = new SelectList(db.Hotels, "ID", "Name", imageHotel.HotelID);
            return View(imageHotel);
        }

        // POST: ImageHotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Image,HotelID")] ImageHotel imageHotel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imageHotel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HotelID = new SelectList(db.Hotels, "ID", "Name", imageHotel.HotelID);
            return View(imageHotel);
        }

        // GET: ImageHotels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageHotel imageHotel = db.HotelImages.Find(id);
            if (imageHotel == null)
            {
                return HttpNotFound();
            }
            return View(imageHotel);
        }

        // POST: ImageHotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImageHotel imageHotel = db.HotelImages.Find(id);
            db.HotelImages.Remove(imageHotel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
