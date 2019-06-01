namespace Game_Arena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRent : DbMigration
    {
        public override void Up()
        {
           
            CreateTable(
                "dbo.RentedGames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HomeAddress = c.String(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                        Game_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.Game_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Game_Id);
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HomeAddress = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Customer_Id = c.Int(nullable: false),
                        Game_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.RentedGames", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.RentedGames", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.RentedGames", new[] { "Game_Id" });
            DropIndex("dbo.RentedGames", new[] { "Customer_Id" });
            DropTable("dbo.RentedGames");
            CreateIndex("dbo.Rentals", "Game_Id");
            CreateIndex("dbo.Rentals", "Customer_Id");
            AddForeignKey("dbo.Rentals", "Game_Id", "dbo.Games", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
