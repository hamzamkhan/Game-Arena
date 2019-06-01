namespace Game_Arena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContactNumberToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ContactNumber", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ContactNumber");
        }
    }
}
