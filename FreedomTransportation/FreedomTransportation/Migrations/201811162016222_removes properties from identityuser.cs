namespace FreedomTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removespropertiesfromidentityuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserRole", c => c.String());
            DropColumn("dbo.AspNetUsers", "firstName");
            DropColumn("dbo.AspNetUsers", "lastName");
            DropColumn("dbo.AspNetUsers", "phone");
            DropColumn("dbo.AspNetUsers", "street");
            DropColumn("dbo.AspNetUsers", "city");
            DropColumn("dbo.AspNetUsers", "state");
            DropColumn("dbo.AspNetUsers", "zip");
            DropColumn("dbo.AspNetUsers", "accountType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "accountType", c => c.String());
            AddColumn("dbo.AspNetUsers", "zip", c => c.String());
            AddColumn("dbo.AspNetUsers", "state", c => c.String());
            AddColumn("dbo.AspNetUsers", "city", c => c.String());
            AddColumn("dbo.AspNetUsers", "street", c => c.String());
            AddColumn("dbo.AspNetUsers", "phone", c => c.String());
            AddColumn("dbo.AspNetUsers", "lastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "firstName", c => c.String());
            DropColumn("dbo.AspNetUsers", "UserRole");
        }
    }
}
