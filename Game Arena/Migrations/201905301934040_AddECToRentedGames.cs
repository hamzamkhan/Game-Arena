namespace Game_Arena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddECToRentedGames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RentedGames", "Email", c => c.String(nullable: false));
            AddColumn("dbo.RentedGames", "ContactNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RentedGames", "ContactNumber");
            DropColumn("dbo.RentedGames", "Email");
        }
    }
}
