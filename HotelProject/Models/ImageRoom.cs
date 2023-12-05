using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelProject.Models
{
    public class ImageRoom
    {
        public int ID { get; set; }
        [NotMapped] public HttpPostedFileBase Image { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
    }
}