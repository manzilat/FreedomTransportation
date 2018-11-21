namespace FreedomTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class undoallthechanges : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SchedulingRides", "Date");
            DropColumn("dbo.SchedulingRides", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SchedulingRides", "Time", c => c.String(nullable: false));
            AddColumn("dbo.SchedulingRides", "Date", c => c.DateTime(nullable: false));
        }
    }
}
