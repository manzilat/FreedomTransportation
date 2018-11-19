namespace FreedomTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class replacedcustomeridintocustomerwalletid : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Customers", name: "CustomerId", newName: "CustomerWalletId");
            RenameIndex(table: "dbo.Customers", name: "IX_CustomerId", newName: "IX_CustomerWalletId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Customers", name: "IX_CustomerWalletId", newName: "IX_CustomerId");
            RenameColumn(table: "dbo.Customers", name: "CustomerWalletId", newName: "CustomerId");
        }
    }
}
