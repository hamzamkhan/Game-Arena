namespace Game_Arena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriceToGame : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "Price");
        }
    }
}
