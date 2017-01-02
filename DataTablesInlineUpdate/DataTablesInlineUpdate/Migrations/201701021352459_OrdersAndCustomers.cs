namespace DataTablesInlineUpdate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrdersAndCustomers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        ArticleNumber = c.String(),
                        ArticleName = c.String(),
                        Description = c.String(),
                        Ean = c.String(),
                        NumberOfItemsPerBox = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MainImage = c.String(),
                        Sort = c.Int(nullable: false),
                        Width = c.Decimal(precision: 18, scale: 2),
                        Height = c.Decimal(precision: 18, scale: 2),
                        Depth = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ArticleId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        Article_ArticleId = c.Int(),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Articles", t => t.Article_ArticleId)
                .Index(t => t.Article_ArticleId);
            
            CreateTable(
                "dbo.BillingAddresses",
                c => new
                    {
                        BillingAddressId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Address3 = c.String(),
                        PostCode = c.String(),
                        City = c.String(),
                        CountryCode = c.String(),
                        PhoneNumber = c.String(),
                        MobileNumber = c.String(),
                        MailAddress = c.String(),
                    })
                .PrimaryKey(t => t.BillingAddressId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerNumber = c.Int(nullable: false),
                        ShippingAddressId = c.Int(nullable: false),
                        BillingAddressId = c.Int(nullable: false),
                        CustomerName = c.String(),
                        OrganisationNumber = c.String(),
                        CountryCode = c.String(),
                        ContactName = c.String(),
                        MailAddress = c.String(),
                        PhoneNumber = c.String(),
                        MobileNumber = c.String(),
                        AccountId = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.BillingAddresses", t => t.BillingAddressId, cascadeDelete: true)
                .ForeignKey("dbo.ShippingAddresses", t => t.ShippingAddressId, cascadeDelete: true)
                .Index(t => t.ShippingAddressId)
                .Index(t => t.BillingAddressId);
            
            CreateTable(
                "dbo.ShippingAddresses",
                c => new
                    {
                        ShippingAddressId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Address3 = c.String(),
                        PostCode = c.String(),
                        City = c.String(),
                        CountryCode = c.String(),
                        PhoneNumber = c.String(),
                        MobileNumber = c.String(),
                        MailAddress = c.String(),
                    })
                .PrimaryKey(t => t.ShippingAddressId);
            
            CreateTable(
                "dbo.OrderLines",
                c => new
                    {
                        OrderLineId = c.Int(nullable: false, identity: true),
                        NumberOfItems = c.Int(nullable: false),
                        PickedNumberOfItems = c.Int(nullable: false),
                        ArticleId = c.Int(nullable: false),
                        DeliveryDate = c.DateTime(),
                        CreatedDate = c.DateTime(nullable: false),
                        Order_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderLineId)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_OrderId)
                .Index(t => t.ArticleId)
                .Index(t => t.Order_OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderNumber = c.String(),
                        OngoingOrderId = c.Int(nullable: false),
                        CustomerNumber = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        CartIdentifier = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
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
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.OrderLines", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.OrderLines", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Customers", "ShippingAddressId", "dbo.ShippingAddresses");
            DropForeignKey("dbo.Customers", "BillingAddressId", "dbo.BillingAddresses");
            DropForeignKey("dbo.Images", "Article_ArticleId", "dbo.Articles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.OrderLines", new[] { "Order_OrderId" });
            DropIndex("dbo.OrderLines", new[] { "ArticleId" });
            DropIndex("dbo.Customers", new[] { "BillingAddressId" });
            DropIndex("dbo.Customers", new[] { "ShippingAddressId" });
            DropIndex("dbo.Images", new[] { "Article_ArticleId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderLines");
            DropTable("dbo.ShippingAddresses");
            DropTable("dbo.Customers");
            DropTable("dbo.BillingAddresses");
            DropTable("dbo.Images");
            DropTable("dbo.Articles");
        }
    }
}
