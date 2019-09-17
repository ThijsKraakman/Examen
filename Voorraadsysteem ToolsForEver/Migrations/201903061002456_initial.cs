namespace Voorraadsysteem_ToolsForEver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fabrikants",
                c => new
                    {
                        FabrikantId = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Telefoonnummer = c.String(),
                    })
                .PrimaryKey(t => t.FabrikantId);
            
            CreateTable(
                "dbo.ProductFabrikant_regel",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        FabrikantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.FabrikantId })
                .ForeignKey("dbo.Fabrikants", t => t.FabrikantId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.FabrikantId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Type = c.String(),
                        InkoopPrijs = c.Double(nullable: false),
                        VerkoopPrijs = c.Double(nullable: false),
                        MinimaalAantal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductVoorraad_regel",
                c => new
                    {
                        VoorraadItemId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VoorraadItemId, t.ProductId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Voorraads", t => t.VoorraadItemId, cascadeDelete: true)
                .Index(t => t.VoorraadItemId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Voorraads",
                c => new
                    {
                        VoorraadItemId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.VoorraadItemId);
            
            CreateTable(
                "dbo.ProductLocatie_regel",
                c => new
                    {
                        VoorraadItemId = c.Int(nullable: false),
                        LocatieId = c.Int(nullable: false),
                        Aantal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VoorraadItemId, t.LocatieId })
                .ForeignKey("dbo.Locaties", t => t.LocatieId, cascadeDelete: true)
                .ForeignKey("dbo.Voorraads", t => t.VoorraadItemId, cascadeDelete: true)
                .Index(t => t.VoorraadItemId)
                .Index(t => t.LocatieId);
            
            CreateTable(
                "dbo.Locaties",
                c => new
                    {
                        LocatieId = c.Int(nullable: false, identity: true),
                        Adres = c.String(),
                        Postcode = c.String(),
                        Plaats = c.String(),
                    })
                .PrimaryKey(t => t.LocatieId);
            
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
            DropForeignKey("dbo.ProductVoorraad_regel", "VoorraadItemId", "dbo.Voorraads");
            DropForeignKey("dbo.ProductLocatie_regel", "VoorraadItemId", "dbo.Voorraads");
            DropForeignKey("dbo.ProductLocatie_regel", "LocatieId", "dbo.Locaties");
            DropForeignKey("dbo.ProductVoorraad_regel", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductFabrikant_regel", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductFabrikant_regel", "FabrikantId", "dbo.Fabrikants");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ProductLocatie_regel", new[] { "LocatieId" });
            DropIndex("dbo.ProductLocatie_regel", new[] { "VoorraadItemId" });
            DropIndex("dbo.ProductVoorraad_regel", new[] { "ProductId" });
            DropIndex("dbo.ProductVoorraad_regel", new[] { "VoorraadItemId" });
            DropIndex("dbo.ProductFabrikant_regel", new[] { "FabrikantId" });
            DropIndex("dbo.ProductFabrikant_regel", new[] { "ProductId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Locaties");
            DropTable("dbo.ProductLocatie_regel");
            DropTable("dbo.Voorraads");
            DropTable("dbo.ProductVoorraad_regel");
            DropTable("dbo.Products");
            DropTable("dbo.ProductFabrikant_regel");
            DropTable("dbo.Fabrikants");
        }
    }
}
