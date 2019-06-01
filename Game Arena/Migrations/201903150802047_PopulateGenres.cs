namespace Game_Arena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'RPG')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Sports')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Racing')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'FPS')");
        }
        
        public override void Down()
        {
        }
    }
}
