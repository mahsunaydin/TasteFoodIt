namespace TasteFoodItx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig6AddChefClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chefs",
                c => new
                    {
                        ChefId = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.ChefId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Chefs");
        }
    }
}
