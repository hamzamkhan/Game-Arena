namespace Game_Arena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveReleaseDateFromGames : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Games", "ReleaseDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "ReleaseDate", c => c.DateTime());
        }
    }
}
