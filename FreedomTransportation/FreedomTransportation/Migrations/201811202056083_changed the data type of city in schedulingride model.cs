namespace FreedomTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedthedatatypeofcityinschedulingridemodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SchedulingRides", "DropoffCity", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SchedulingRides", "DropoffCity", c => c.Int(nullable: false));
        }
    }
}
