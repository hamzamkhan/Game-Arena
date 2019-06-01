namespace Game_Arena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePriceDatatype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Games", "Price", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Games", "Price", c => c.Int(nullable: false));
        }
    }
}
