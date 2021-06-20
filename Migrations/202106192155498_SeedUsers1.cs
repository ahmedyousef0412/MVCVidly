namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"

             INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'49df39df-1335-4b7f-8c76-6f38725afc37', N'other@gmail.com', 0, N'AAlhDcsVQjBGHxoH+Z+Con722JbbQ9YADN3ai8tvHGuY4IMGHlELe4yOlPm4RtXbwg==', N'd327946d-f045-4149-9256-06b3450d462e', NULL, 0, 0, NULL, 1, 0, N'other@gmail.com')

              INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9e0f1bb2-786c-4b89-841b-1b4abe8bb573', N'lajja@vidly.com', 0, N'ALXVUqVc+mD1LxNIIbbyrwPo/6PjM1AqNQypBmbjSgPLt0jVYvjRr+DSa4Jl2IAtxA==', N'43fc7da8-0dd7-4da7-930a-fc335cdecb99', NULL, 0, 0, NULL, 1, 0, N'lajja@vidly.com')


INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd703c9e7-1219-45c9-bec4-87b2032c9691', N'CanMangeMovies')


INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9e0f1bb2-786c-4b89-841b-1b4abe8bb573', N'd703c9e7-1219-45c9-bec4-87b2032c9691')

");

        }
        
        public override void Down()
        {
        }
    }
}
