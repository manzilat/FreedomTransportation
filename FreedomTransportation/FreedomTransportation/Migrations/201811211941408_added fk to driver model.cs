namespace FreedomTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfktodrivermodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Drivers", "ApplicationUserId");
            AddForeignKey("dbo.Drivers", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drivers", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Drivers", new[] { "ApplicationUserId" });
            DropColumn("dbo.Drivers", "ApplicationUserId");
        }
    }
}
