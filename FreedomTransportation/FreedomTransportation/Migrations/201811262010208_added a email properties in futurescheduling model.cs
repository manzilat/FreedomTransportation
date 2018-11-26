namespace FreedomTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedaemailpropertiesinfutureschedulingmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FutureSchedules", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FutureSchedules", "Email");
        }
    }
}
