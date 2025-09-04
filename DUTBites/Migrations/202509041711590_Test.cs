namespace DUTBites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campus",
                c => new
                    {
                        CampusID = c.Int(nullable: false, identity: true),
                        CampusName = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.CampusID);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreID = c.Int(nullable: false, identity: true),
                        CampusID = c.Int(nullable: false),
                        StoreName = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.StoreID)
                .ForeignKey("dbo.Campus", t => t.CampusID)
                .Index(t => t.CampusID);
            
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        StoreID = c.Int(nullable: false),
                        itemName = c.String(),
                        itemDescription = c.String(),
                        itemPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.Stores", t => t.StoreID)
                .Index(t => t.StoreID);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemID = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        MenuItemId = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        notes = c.String(),
                    })
                .PrimaryKey(t => t.OrderItemID)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.MenuItems", t => t.MenuItemId)
                .Index(t => t.OrderId)
                .Index(t => t.MenuItemId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                        DriverId = c.Int(),
                        status = c.Int(nullable: false),
                        orderDate = c.DateTime(nullable: false),
                        totalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.DeliveryDrivers", t => t.DriverId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Stores", t => t.StoreId)
                .Index(t => t.UserId)
                .Index(t => t.StoreId)
                .Index(t => t.DriverId);
            
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        DeliveryID = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        DriverID = c.Int(nullable: false),
                        status = c.Int(nullable: false),
                        assignedAt = c.DateTime(nullable: false),
                        completedAt = c.DateTime(nullable: false),
                        Order_OrderID = c.Int(),
                    })
                .PrimaryKey(t => t.DeliveryID)
                .ForeignKey("dbo.DeliveryDrivers", t => t.DriverID)
                .ForeignKey("dbo.Orders", t => t.Order_OrderID)
                .ForeignKey("dbo.Orders", t => t.DeliveryID)
                .Index(t => t.DeliveryID)
                .Index(t => t.DriverID)
                .Index(t => t.Order_OrderID);
            
            CreateTable(
                "dbo.DeliveryDrivers",
                c => new
                    {
                        DriverID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        LicensePlate = c.String(),
                        DriverLicenseNumber = c.String(),
                        LicenseExpiryDate = c.DateTime(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        LastKnownLocationTimestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DriverID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.DeliveryLocations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        DriverID = c.Int(nullable: false),
                        latitude = c.Single(nullable: false),
                        longitude = c.Single(nullable: false),
                        timestamp = c.DateTime(nullable: false),
                        Delivery_DeliveryID = c.Int(),
                    })
                .PrimaryKey(t => t.LocationID)
                .ForeignKey("dbo.DeliveryDrivers", t => t.DriverID, cascadeDelete: true)
                .ForeignKey("dbo.Deliveries", t => t.Delivery_DeliveryID)
                .Index(t => t.DriverID)
                .Index(t => t.Delivery_DeliveryID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        CampusID = c.Int(nullable: false),
                        Role = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Campus", t => t.CampusID)
                .Index(t => t.CampusID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        method = c.Int(nullable: false),
                        status = c.Int(nullable: false),
                        paidAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.PaymentID)
                .Index(t => t.PaymentID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "CampusID", "dbo.Campus");
            DropForeignKey("dbo.Stores", "CampusID", "dbo.Campus");
            DropForeignKey("dbo.Orders", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.MenuItems", "StoreID", "dbo.Stores");
            DropForeignKey("dbo.OrderItems", "MenuItemId", "dbo.MenuItems");
            DropForeignKey("dbo.Payments", "PaymentID", "dbo.Orders");
            DropForeignKey("dbo.Payments", "UserID", "dbo.Users");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Deliveries", "DeliveryID", "dbo.Orders");
            DropForeignKey("dbo.Deliveries", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.DeliveryLocations", "Delivery_DeliveryID", "dbo.Deliveries");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.DeliveryDrivers", "UserID", "dbo.Users");
            DropForeignKey("dbo.Orders", "DriverId", "dbo.DeliveryDrivers");
            DropForeignKey("dbo.DeliveryLocations", "DriverID", "dbo.DeliveryDrivers");
            DropForeignKey("dbo.Deliveries", "DriverID", "dbo.DeliveryDrivers");
            DropIndex("dbo.Payments", new[] { "UserID" });
            DropIndex("dbo.Payments", new[] { "PaymentID" });
            DropIndex("dbo.Users", new[] { "CampusID" });
            DropIndex("dbo.DeliveryLocations", new[] { "Delivery_DeliveryID" });
            DropIndex("dbo.DeliveryLocations", new[] { "DriverID" });
            DropIndex("dbo.DeliveryDrivers", new[] { "UserID" });
            DropIndex("dbo.Deliveries", new[] { "Order_OrderID" });
            DropIndex("dbo.Deliveries", new[] { "DriverID" });
            DropIndex("dbo.Deliveries", new[] { "DeliveryID" });
            DropIndex("dbo.Orders", new[] { "DriverId" });
            DropIndex("dbo.Orders", new[] { "StoreId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.OrderItems", new[] { "MenuItemId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.MenuItems", new[] { "StoreID" });
            DropIndex("dbo.Stores", new[] { "CampusID" });
            DropTable("dbo.Payments");
            DropTable("dbo.Users");
            DropTable("dbo.DeliveryLocations");
            DropTable("dbo.DeliveryDrivers");
            DropTable("dbo.Deliveries");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.MenuItems");
            DropTable("dbo.Stores");
            DropTable("dbo.Campus");
        }
    }
}
