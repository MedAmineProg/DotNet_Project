namespace HotelProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageHotel",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        HotelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Hotel", t => t.HotelID, cascadeDelete: true)
                .Index(t => t.HotelID);
            
            CreateTable(
                "dbo.Hotel",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        Description = c.String(),
                        Stars = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageHotel", "HotelID", "dbo.Hotel");
            DropIndex("dbo.ImageHotel", new[] { "HotelID" });
            DropTable("dbo.Hotel");
            DropTable("dbo.ImageHotel");
        }
    }
}
