namespace Game_Arena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropEC : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RentedGames", "Email");
            DropColumn("dbo.RentedGames", "ContactNumber");
        }
        
        public override void Down()
        {
            
        }
    }
}
