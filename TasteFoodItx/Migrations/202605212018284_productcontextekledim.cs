namespace TasteFoodItx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productcontextekledim : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        ReservationDate = c.DateTime(nullable: false),
                        Time = c.String(),
                        GuestCount = c.Byte(nullable: false),
                        ReservationStatus = c.String(),
                    })
                .PrimaryKey(t => t.ReservationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reservations");
        }
    }
}
