namespace My_Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixAddedNumberAvailableToMovies : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SEt NumberAvailable = InStock");
        }
        
        public override void Down()
        {
        }
    }
}
