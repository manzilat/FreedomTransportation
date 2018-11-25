namespace FreedomTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Street = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        City = c.String(),
                        lat = c.String(),
                        lng = c.String(),
                        CustomerWalletId = c.Int(),
                        SchedulingRideId = c.Int(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.CustomerWallets", t => t.CustomerWalletId)
                .ForeignKey("dbo.SchedulingRides", t => t.SchedulingRideId)
                .Index(t => t.CustomerWalletId)
                .Index(t => t.SchedulingRideId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserRole = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.CustomerWallets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        NameOnTheCard = c.String(),
                        CreditCard = c.String(),
                        ExpirationDate = c.String(),
                        CvvNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SchedulingRides",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PickupAddress = c.String(),
                        PickupCity = c.String(),
                        PickupState = c.String(),
                        PickupZipCode = c.String(),
                        DropoffAddress = c.String(),
                        DropoffCity = c.String(),
                        DropoffState = c.String(),
                        DropoffZipCode = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DriversLicense = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Street = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        City = c.String(),
                        Status = c.String(),
                        CustomerId = c.Int(),
                        TripsId = c.Int(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Trips", t => t.TripsId)
                .Index(t => t.CustomerId)
                .Index(t => t.TripsId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PickUpTime = c.DateTime(nullable: false),
                        ArrivalTime = c.DateTime(nullable: false),
                        DepartureTime = c.DateTime(nullable: false),
                        DropOffTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.TransportationProviders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProviderName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Street = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        City = c.String(),
                        lat = c.String(),
                        lng = c.String(),
                        DriverId = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .Index(t => t.DriverId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransportationProviders", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.TransportationProviders", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Drivers", "TripsId", "dbo.Trips");
            DropForeignKey("dbo.Drivers", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Drivers", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "SchedulingRideId", "dbo.SchedulingRides");
            DropForeignKey("dbo.SchedulingRides", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "CustomerWalletId", "dbo.CustomerWallets");
            DropForeignKey("dbo.Customers", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.TransportationProviders", new[] { "ApplicationUserId" });
            DropIndex("dbo.TransportationProviders", new[] { "DriverId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Drivers", new[] { "ApplicationUserId" });
            DropIndex("dbo.Drivers", new[] { "TripsId" });
            DropIndex("dbo.Drivers", new[] { "CustomerId" });
            DropIndex("dbo.SchedulingRides", new[] { "ApplicationUserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Customers", new[] { "ApplicationUserId" });
            DropIndex("dbo.Customers", new[] { "SchedulingRideId" });
            DropIndex("dbo.Customers", new[] { "CustomerWalletId" });
            DropTable("dbo.TransportationProviders");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Trips");
            DropTable("dbo.Drivers");
            DropTable("dbo.SchedulingRides");
            DropTable("dbo.CustomerWallets");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Customers");
        }
    }
}
