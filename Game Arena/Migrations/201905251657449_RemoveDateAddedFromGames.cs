namespace Game_Arena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDateAddedFromGames : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Games", "DateAdded");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "DateAdded", c => c.DateTime());
        }
    }
}
