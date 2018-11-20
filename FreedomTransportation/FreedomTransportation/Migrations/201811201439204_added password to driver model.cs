namespace FreedomTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpasswordtodrivermodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drivers", "Password");
        }
    }
}
