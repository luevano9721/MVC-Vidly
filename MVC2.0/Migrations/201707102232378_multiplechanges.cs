namespace MVC2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class multiplechanges : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE dbo.Movies DROP CONSTRAINT DF__Movies__InStock__2B3F6F97");
            AlterColumn("dbo.Movies", "InStock", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "InStock", c => c.Int(nullable: false));
        }
    }
}
