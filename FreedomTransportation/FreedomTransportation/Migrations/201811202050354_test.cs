namespace FreedomTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SchedulingRides", "lat");
            DropColumn("dbo.SchedulingRides", "lng");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SchedulingRides", "lng", c => c.String());
            AddColumn("dbo.SchedulingRides", "lat", c => c.String());
        }
    }
}
