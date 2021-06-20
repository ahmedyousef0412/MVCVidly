namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {

            Sql(@"

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7dffdc3b-8353-4042-b8f8-3640fef90ad1', N'admin@vidly.com', 0, N'AIwM9oB4FFtaadNnjCRkCbEnlVxvfgqc5WXTTKUgkyv+vjKv6+L5SkBKbL1FgN9R6w==', N'969ab513-1d99-4c4d-85c4-c48fe5aaef72', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bd5bac93-e357-444b-ab2e-de57517afac9', N'guest@vidly.com', 0, N'AEWTv8CTUvfqL+gFUy3CAGzPOvYRQ6EEJUy9NNY+WSGbAuRVbYM9zKoqrYhH5GYmHg==', N'cbf477b0-91cc-4493-88ed-80b7b0cf296d', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c1b5292d-49ad-4b16-a067-11fd22f21c5a', N'Can Mange Movies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7dffdc3b-8353-4042-b8f8-3640fef90ad1', N'c1b5292d-49ad-4b16-a067-11fd22f21c5a')


               ");
        } 
        
        public override void Down()
        {
        }
    }
}
