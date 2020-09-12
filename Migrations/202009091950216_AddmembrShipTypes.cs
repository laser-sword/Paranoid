namespace Paranoid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddmembrShipTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MemberShipType_SignUpFee", c => c.Short(nullable: false));
            AddColumn("dbo.Customers", "MemberShipType_DurationInMonths", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "MemberShipType_DiscountRate", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "MemberShipTypeId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "MemberShipTypeId");
            DropColumn("dbo.Customers", "MemberShipType_DiscountRate");
            DropColumn("dbo.Customers", "MemberShipType_DurationInMonths");
            DropColumn("dbo.Customers", "MemberShipType_SignUpFee");
        }
    }
}
