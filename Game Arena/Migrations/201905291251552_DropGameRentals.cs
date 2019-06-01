namespace Game_Arena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropGameRentals : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.GameRentals");

        }

        public override void Down()
        {
        }
    }
}
