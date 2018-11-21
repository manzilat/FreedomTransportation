namespace FreedomTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedaforeignkeytoschedulingride : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SchedulingRides", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.SchedulingRides", "ApplicationUserId");
            AddForeignKey("dbo.SchedulingRides", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SchedulingRides", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.SchedulingRides", new[] { "ApplicationUserId" });
            DropColumn("dbo.SchedulingRides", "ApplicationUserId");
        }
    }
}
