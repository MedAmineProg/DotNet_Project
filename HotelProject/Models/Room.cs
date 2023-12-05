using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelProject.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Reserve { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public int Nb_Persons { get; set; }
        public virtual ICollection<ImageRoom> Images { get; set; }

        public int HotelID { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}