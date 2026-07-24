namespace TasteFoodItx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChefClass : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Chefs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Chefs",
                c => new
                    {
                        ChefId = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ChefId);
            
        }
    }
}
