namespace MVC2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1e44e50f-2ef1-4399-a5f1-a2de5a93c3a8', N'admin@vidly.com', 0, N'ANdB01lZjouW2R8s5cEah7d9KI5iev0CVFpXBHWJjI8h+DyFJGOYNT740eAwceWD/g==', N'fa70fe4e-1e24-4286-a5cf-dfa55661e8f1', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bc26f1eb-b7f7-40d9-baff-e804e8372bc0', N'guest@vidly.com', 0, N'AHhsyW8KhZWsopqM1eAtK649r1RoClThfTP+x0oBZK+6S9dV4pq1kPOFPGVyJcEd0Q==', N'632c16e5-2182-4e1b-b1f5-41dce69b7daf', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bfafeacd-b9dd-4e19-b9f2-b607e5945a24', N'CanManageMovie')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1e44e50f-2ef1-4399-a5f1-a2de5a93c3a8', N'bfafeacd-b9dd-4e19-b9f2-b607e5945a24')

");
        }
        
        public override void Down()
        {
        }
    }
}
