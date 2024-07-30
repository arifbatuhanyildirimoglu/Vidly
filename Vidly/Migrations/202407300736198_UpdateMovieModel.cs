namespace Vidly.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class UpdateMovieModel : DbMigration
	{
		public override void Up()
		{
			AddColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
			AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
			AlterColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));

			Sql("UPDATE Movies SET NumberAvailable = NumberInStock");
		}

		public override void Down()
		{
			AlterColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
			AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
			DropColumn("dbo.Movies", "NumberAvailable");
		}
	}
}
