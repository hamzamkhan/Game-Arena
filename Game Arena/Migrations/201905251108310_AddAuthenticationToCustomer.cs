namespace Game_Arena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuthenticationToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Customers", "IsSubscribeToNewsLetter");
            DropColumn("dbo.Customers", "BirthDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "BirthDate", c => c.DateTime());
            AddColumn("dbo.Customers", "IsSubscribeToNewsLetter", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Customers", "Name", c => c.String(maxLength: 255));
            DropColumn("dbo.Customers", "Password");
            DropColumn("dbo.Customers", "Email");
        }
    }
}
