namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddDataToMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MOVIES (Title,Genre,DateReleased,PiecesInStock) VALUES ('Hera Pheri','Comedy',10/10/1998, 18)");
        }

        public override void Down()
        {
        }
    }
}
