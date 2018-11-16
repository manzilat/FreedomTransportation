namespace FreedomTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gotridofrequiredattributeonappuser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "firstName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "lastName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "phone", c => c.String());
            AlterColumn("dbo.AspNetUsers", "street", c => c.String());
            AlterColumn("dbo.AspNetUsers", "city", c => c.String());
            AlterColumn("dbo.AspNetUsers", "state", c => c.String());
            AlterColumn("dbo.AspNetUsers", "zip", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "zip", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "state", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "city", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "street", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "phone", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "lastName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "firstName", c => c.String(nullable: false));
        }
    }
}
