namespace My_Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense]) VALUES (N'1317e559-de29-41e0-b99e-5b55ada750fb', N'guest@gmail.com', 0, N'AK5kKypUEpWHcxkmYnpnh0I/NDzOfcNtLq85UuxFn188pTfI9XaxJj90TU2i2TJQUA==', N'869b64a2-b76a-4913-b2da-b15699e93325', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com', N'Guest')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense]) VALUES (N'e558a9d8-0bfa-454b-a6ec-1900a3609fc2', N'admin@gmail.com', 0, N'AH9y/vkEAMlwRiaFccmmznDGi8ryzmfeZIQa6M42ZcES3Fd0m9ZGIiYTic2txFKb9A==', N'565b4229-c630-455a-93c2-56d4d0516536', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com', N'Hello')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bd0175dd-819e-415c-8f38-9836216997b4', N'CanManageCustomers')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9fe2b2f8-41ff-4a3c-96bd-ef01c5f36b6f', N'CanManageMovies')


INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e558a9d8-0bfa-454b-a6ec-1900a3609fc2', N'9fe2b2f8-41ff-4a3c-96bd-ef01c5f36b6f')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e558a9d8-0bfa-454b-a6ec-1900a3609fc2', N'bd0175dd-819e-415c-8f38-9836216997b4')

");
        }
        
        public override void Down()
        {
        }
    }
}
