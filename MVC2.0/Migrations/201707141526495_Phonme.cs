namespace MVC2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Phonme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Phone", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Phone");
        }
    }
}