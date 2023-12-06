using HotelProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HotelProject.DAL
{
    public class HotelContext : DbContext
    {

        public HotelContext() : base("HotelContext")
        {
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<ImageHotel> HotelImages { get; set; }

        public DbSet<ImageRoom> ImageRoom { get; set; }

        public DbSet<Room> Room { get; set; }

        public DbSet<User> User { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}