namespace Paranoid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMemberShipTypes1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemberShipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Customers", "MemberShipTypeId");
            AddForeignKey("dbo.Customers", "MemberShipTypeId", "dbo.MemberShipTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "MemberShipType_SignUpFee");
            DropColumn("dbo.Customers", "MemberShipType_DurationInMonths");
            DropColumn("dbo.Customers", "MemberShipType_DiscountRate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MemberShipType_DiscountRate", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "MemberShipType_DurationInMonths", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "MemberShipType_SignUpFee", c => c.Short(nullable: false));
            DropForeignKey("dbo.Customers", "MemberShipTypeId", "dbo.MemberShipTypes");
            DropIndex("dbo.Customers", new[] { "MemberShipTypeId" });
            DropTable("dbo.MemberShipTypes");
        }
    }
}
