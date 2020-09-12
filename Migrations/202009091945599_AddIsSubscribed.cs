namespace Paranoid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubscribed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscibedToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubscibedToNewsLetter");
        }
    }
}
