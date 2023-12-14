using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelProject.Models
{
    public class ImageHotel
    {
        public int ID { get; set; }
        public byte[] Image { get; set; }
        public int HotelID { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}