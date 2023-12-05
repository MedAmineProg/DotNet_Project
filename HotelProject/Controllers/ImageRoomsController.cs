using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelProject.DAL;
using HotelProject.Models;

namespace HotelProject.Controllers
{
    public class ImageRoomsController : Controller
    {
        private HotelContext db = new HotelContext();

        // GET: ImageRooms
        public ActionResult Index()
        {
            var imageRoom = db.ImageRoom.Include(i => i.Room);
            return View(imageRoom.ToList());
        }

        // GET: ImageRooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageRoom imageRoom = db.ImageRoom.Find(id);
            if (imageRoom == null)
            {
                return HttpNotFound();
            }
            return View(imageRoom);
        }

        // GET: ImageRooms/Create
        public ActionResult Create()
        {
            ViewBag.RoomId = new SelectList(db.Room, "ID", "Name");
            return View();
        }

        // POST: ImageRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RoomId")] ImageRoom imageRoom)
        {
            if (ModelState.IsValid)
            {
                db.ImageRoom.Add(imageRoom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoomId = new SelectList(db.Room, "ID", "Name", imageRoom.RoomId);
            return View(imageRoom);
        }

        // GET: ImageRooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageRoom imageRoom = db.ImageRoom.Find(id);
            if (imageRoom == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomId = new SelectList(db.Room, "ID", "Name", imageRoom.RoomId);
            return View(imageRoom);
        }

        // POST: ImageRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RoomId")] ImageRoom imageRoom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imageRoom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoomId = new SelectList(db.Room, "ID", "Name", imageRoom.RoomId);
            return View(imageRoom);
        }

        // GET: ImageRooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageRoom imageRoom = db.ImageRoom.Find(id);
            if (imageRoom == null)
            {
                return HttpNotFound();
            }
            return View(imageRoom);
        }

        // POST: ImageRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImageRoom imageRoom = db.ImageRoom.Find(id);
            db.ImageRoom.Remove(imageRoom);
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
