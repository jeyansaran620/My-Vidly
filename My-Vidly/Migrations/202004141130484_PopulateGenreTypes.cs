namespace My_Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (0,'Comedy')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (1,'Thriller')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (2,'Horror')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (3,'Romantic')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (4,'Drama')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (5,'Action')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (6,'Sci-Fci')");

        }

        public override void Down()
        {
        }
    }
}
