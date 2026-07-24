namespace TasteFoodItx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3NotificationTblAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        description = c.String(),
                        IsRead = c.Boolean(nullable: false),
                        NotificationIcon = c.String(),
                    })
                .PrimaryKey(t => t.NotificationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notifications");
        }
    }
}
