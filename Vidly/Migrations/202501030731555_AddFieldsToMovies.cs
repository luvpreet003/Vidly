namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldsToMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String());
            AddColumn("dbo.Movies", "DateReleased", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "PiecesInStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "PiecesInStock");
            DropColumn("dbo.Movies", "DateReleased");
            DropColumn("dbo.Movies", "Genre");
        }
    }
}
