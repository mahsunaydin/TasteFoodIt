namespace TasteFoodItx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig7SliderClassAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        SliderId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Header = c.String(),
                        Subheader = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.SliderId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sliders");
        }
    }
}
