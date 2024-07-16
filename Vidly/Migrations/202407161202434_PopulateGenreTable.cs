namespace Vidly.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class PopulateGenreTable : DbMigration
	{
		public override void Up()
		{
			Sql("INSERT INTO Genres (Name) VALUES ('Action')");
			Sql("INSERT INTO Genres (Name) VALUES ('Thriller')");
			Sql("INSERT INTO Genres (Name) VALUES ('Family')");
			Sql("INSERT INTO Genres (Name) VALUES ('Romance')");
			Sql("INSERT INTO Genres (Name) VALUES ('Comedy')");
		}

		public override void Down()
		{
		}
	}
}
