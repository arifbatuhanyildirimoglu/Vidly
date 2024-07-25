namespace Vidly.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class SeedUsers : DbMigration
	{
		public override void Up()
		{
			Sql(@"
			INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'db9ffe08-7109-47fd-a379-8babae007327', N'admin@vidly.com', 0, N'AHd0Dmrz2BTYZovqj/BQhWAPF+XSsQhSoxtFUiXCH9PPbAxNiCgQkO91T0Csauapww==', N'602eef08-e6c9-4667-be93-4480777e4aba', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
			
			INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4200a6da-fb99-4738-92d0-d8529c5936bb', N'CanManageMovies')

			INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'db9ffe08-7109-47fd-a379-8babae007327', N'4200a6da-fb99-4738-92d0-d8529c5936bb')
			");
		}

		public override void Down()
		{
		}
	}
}
