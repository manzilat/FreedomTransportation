namespace FreedomTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddateandtimetoschedulingridemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SchedulingRides", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.SchedulingRides", "Time", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SchedulingRides", "Time");
            DropColumn("dbo.SchedulingRides", "Date");
        }
    }
}
