using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelProject.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int Prix_Total { get; set; }
        public string Service { get; set; }
        public DateTime Date_Debut { get; set; }
        public DateTime Date_Fin { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
    }
}