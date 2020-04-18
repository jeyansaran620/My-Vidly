namespace My_Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDobToCustomer1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DOB", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "DOB");
        }
    }
}
