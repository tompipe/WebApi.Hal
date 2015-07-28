namespace WebApi.Hal.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abv = c.Double(nullable: false),
                        Brewery_Id = c.Int(),
                        Style_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Breweries", t => t.Brewery_Id)
                .ForeignKey("dbo.BeerStyles", t => t.Style_Id)
                .Index(t => t.Brewery_Id)
                .Index(t => t.Style_Id);
            
            CreateTable(
                "dbo.Breweries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BeerStyles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Beer_Id = c.Int(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Beers", "Style_Id", "dbo.BeerStyles");
            DropForeignKey("dbo.Beers", "Brewery_Id", "dbo.Breweries");
            DropIndex("dbo.Beers", new[] { "Style_Id" });
            DropIndex("dbo.Beers", new[] { "Brewery_Id" });
            DropTable("dbo.Reviews");
            DropTable("dbo.BeerStyles");
            DropTable("dbo.Breweries");
            DropTable("dbo.Beers");
        }
    }
}
