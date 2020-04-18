namespace My_Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Genretype : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GenreTypeId", "dbo.GenreTypes");
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.GenreTypes");
            DropIndex("dbo.Movies", new[] { "GenreTypeId" });
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            DropColumn("dbo.Movies", "GenreTypeId");
            RenameColumn(table: "dbo.Movies", name: "Genre_Id", newName: "GenreTypeId");
            AlterColumn("dbo.Movies", "GenreTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "GenreTypeId");
            AddForeignKey("dbo.Movies", "GenreTypeId", "dbo.GenreTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreTypeId", "dbo.GenreTypes");
            DropIndex("dbo.Movies", new[] { "GenreTypeId" });
            AlterColumn("dbo.Movies", "GenreTypeId", c => c.Byte());
            RenameColumn(table: "dbo.Movies", name: "GenreTypeId", newName: "Genre_Id");
            AddColumn("dbo.Movies", "GenreTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "Genre_Id");
            CreateIndex("dbo.Movies", "GenreTypeId");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.GenreTypes", "Id");
            AddForeignKey("dbo.Movies", "GenreTypeId", "dbo.GenreTypes", "Id", cascadeDelete: true);
        }
    }
}
