using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelProject.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }
        public virtual ICollection<ImageHotel> Images { get; set; }
    }
}