namespace FreedomTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class walletidandridesarenownullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "CustomerWalletId", "dbo.CustomerWallets");
            DropForeignKey("dbo.Customers", "SchedulingRideId", "dbo.SchedulingRides");
            DropIndex("dbo.Customers", new[] { "CustomerWalletId" });
            DropIndex("dbo.Customers", new[] { "SchedulingRideId" });
            AlterColumn("dbo.Customers", "CustomerWalletId", c => c.Int());
            AlterColumn("dbo.Customers", "SchedulingRideId", c => c.Int());
            CreateIndex("dbo.Customers", "CustomerWalletId");
            CreateIndex("dbo.Customers", "SchedulingRideId");
            AddForeignKey("dbo.Customers", "CustomerWalletId", "dbo.CustomerWallets", "Id");
            AddForeignKey("dbo.Customers", "SchedulingRideId", "dbo.SchedulingRides", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "SchedulingRideId", "dbo.SchedulingRides");
            DropForeignKey("dbo.Customers", "CustomerWalletId", "dbo.CustomerWallets");
            DropIndex("dbo.Customers", new[] { "SchedulingRideId" });
            DropIndex("dbo.Customers", new[] { "CustomerWalletId" });
            AlterColumn("dbo.Customers", "SchedulingRideId", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "CustomerWalletId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "SchedulingRideId");
            CreateIndex("dbo.Customers", "CustomerWalletId");
            AddForeignKey("dbo.Customers", "SchedulingRideId", "dbo.SchedulingRides", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "CustomerWalletId", "dbo.CustomerWallets", "Id", cascadeDelete: true);
        }
    }
}
