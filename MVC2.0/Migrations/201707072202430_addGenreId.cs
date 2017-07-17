namespace MVC2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGenreId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Movies", name: "Genre_id", newName: "GenreId");
            RenameIndex(table: "dbo.Movies", name: "IX_Genre_id", newName: "IX_GenreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Movies", name: "IX_GenreId", newName: "IX_Genre_id");
            RenameColumn(table: "dbo.Movies", name: "GenreId", newName: "Genre_id");
        }
    }
}
