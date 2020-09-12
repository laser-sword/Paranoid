namespace Paranoid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class balls : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MemberShipTypes SET Name = 'Pay as you go!' WHERE Id = 1");
            Sql("UPDATE MemberShipTypes SET Name = 'Monthlyo!' WHERE Id = 2");
            Sql("UPDATE MemberShipTypes SET Name = 'Quarterlyo!' WHERE Id = 3");
            Sql("UPDATE MemberShipTypes SET Name = 'YEarlyo!' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
