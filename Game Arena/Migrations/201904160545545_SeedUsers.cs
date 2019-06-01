namespace Game_Arena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'56e80dbd-3b21-4f1f-8caf-8efa7b22aef8', N'hamza@mail.com', 0, N'AEsUCulpTcmpbnzJR4JmnauWbdH8CRELFL7suRBPIl0+3mYBQclepTyJeiSfCHE6Pg==', N'e284beb0-c452-4e1f-b26e-db11990fde85', NULL, 0, 0, NULL, 1, 0, N'hamza@mail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7b244a4e-5ad7-410c-93ab-3478ff7ee6f9', N'admin@gamearena.com', 0, N'ABWDV7EJYP1FCvdGTlKUo0bEuEhUV8fMPXY7wq26385IcpcsgoUPbW2hqQVOZthZ+w==', N'cf8f2415-c829-493b-b044-87c946017bdf', NULL, 0, 0, NULL, 1, 0, N'admin@gamearena.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'13aa1c75-bca9-471d-a605-e9de760cfdc8', N'CanManageGames')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7b244a4e-5ad7-410c-93ab-3478ff7ee6f9', N'13aa1c75-bca9-471d-a605-e9de760cfdc8')

"); 
        }
        
        public override void Down()
        {
        }
    }
}
