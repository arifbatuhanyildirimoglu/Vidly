namespace Vidly.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class AddNewColumnsToTheMovie : DbMigration
	{
		public override void Up()
		{
			CreateTable(
					"dbo.Movies",
					c => new
					{
						Id = c.Int(nullable: false, identity: true),
						Name = c.String(),
						ReleaseDate = c.DateTime(nullable: false),
						DateAdded = c.DateTime(nullable: false),
						NumberInStock = c.Int(nullable: false),
					})
					.PrimaryKey(t => t.Id);

		}

		public override void Down()
		{
			DropTable("dbo.Movies");
		}
	}
}
