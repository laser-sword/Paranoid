namespace Paranoid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDOBtoCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DOB", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "DOB");
        }
    }
}
