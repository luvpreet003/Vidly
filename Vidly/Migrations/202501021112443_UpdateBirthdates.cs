namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBirthdates : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate = 13/04/1998 WHERE ID = 1");
        }
        
        public override void Down()
        {
        }
    }
}
