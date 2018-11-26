namespace FreedomTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedanewpropertiesinfutureschedulingmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FutureSchedules", "PickupAddress", c => c.String());
            AddColumn("dbo.FutureSchedules", "DropoffAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FutureSchedules", "DropoffAddress");
            DropColumn("dbo.FutureSchedules", "PickupAddress");
        }
    }
}
