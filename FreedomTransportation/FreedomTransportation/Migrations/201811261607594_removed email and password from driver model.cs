namespace FreedomTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedemailandpasswordfromdrivermodel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Drivers", "Password");
            DropColumn("dbo.Drivers", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drivers", "Email", c => c.String());
            AddColumn("dbo.Drivers", "Password", c => c.String());
        }
    }
}
