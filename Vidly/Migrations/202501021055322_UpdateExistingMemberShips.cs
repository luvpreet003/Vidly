namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Web.UI.WebControls.WebParts;

    public partial class UpdateExistingMemberShips : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay as you go' WHERE ID = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' Where ID = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Quarterly' Where ID = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Yearly' Where ID = 4");
        }

        public override void Down()
        {
        }
    }
}
