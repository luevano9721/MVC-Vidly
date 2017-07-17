namespace MVC2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateNameType : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes SET Name='Pay as you go' where Id=1");
            Sql("Update MembershipTypes SET Name='Monthly' where Id=2");
            Sql("Update MembershipTypes SET Name='Quarterly' where Id=3");
            Sql("Update MembershipTypes SET Name='Annual' where Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
