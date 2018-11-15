namespace FreedomTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedkeys : DbMigration
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
                        CustomerId = c.Int(nullable: false),
                        SchedulingRideId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerWallets", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.SchedulingRides", t => t.SchedulingRideId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.SchedulingRideId);
            
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
                        DropoffCity = c.Int(nullable: false),
                        DropoffState = c.String(),
                        DropoffZipCode = c.String(),
                        lat = c.String(),
                        lng = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DriversLicense = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Street = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        City = c.String(),
                        Status = c.String(),
                        DriverRating = c.String(),
                        lat = c.String(),
                        lng = c.String(),
                        CustomerId = c.Int(nullable: false),
                        TripsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Trips", t => t.TripsId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.TripsId);
            
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
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .Index(t => t.DriverId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        firstName = c.String(nullable: false),
                        lastName = c.String(nullable: false),
                        phone = c.String(nullable: false),
                        street = c.String(nullable: false),
                        city = c.String(nullable: false),
                        state = c.String(nullable: false),
                        zip = c.String(nullable: false),
                        accountType = c.String(),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TransportationProviders", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Drivers", "TripsId", "dbo.Trips");
            DropForeignKey("dbo.Drivers", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "SchedulingRideId", "dbo.SchedulingRides");
            DropForeignKey("dbo.Customers", "CustomerId", "dbo.CustomerWallets");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.TransportationProviders", new[] { "DriverId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Drivers", new[] { "TripsId" });
            DropIndex("dbo.Drivers", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "SchedulingRideId" });
            DropIndex("dbo.Customers", new[] { "CustomerId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TransportationProviders");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Trips");
            DropTable("dbo.Drivers");
            DropTable("dbo.SchedulingRides");
            DropTable("dbo.CustomerWallets");
            DropTable("dbo.Customers");
        }
    }
}
