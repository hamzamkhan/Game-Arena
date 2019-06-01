namespace Game_Arena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDBContext : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
