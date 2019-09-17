namespace Voorraadsysteem_ToolsForEver.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Voorraadsysteem_ToolsForEver.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Voorraadsysteem_ToolsForEver.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Voorraadsysteem_ToolsForEver.Models.ApplicationDbContext context)
        {
            //deze code zorgt ervoor dat de database automatisch gevuld word met data

            //Directie rol
            if (!context.Roles.Any(r => r.Name == "Directie"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Directie" };
                manager.Create(role);
            }

            //Directie account
            if (!context.Users.Any(u => u.UserName == "directie@toolsforever.nl"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "directie@toolsforever.nl" };

                manager.Create(user, "Tools4Ever!");
                manager.AddToRole(user.Id, "Directie");
            }

            //BUitendienst rol
            if (!context.Roles.Any(r => r.Name == "Buitendienst"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Buitendienst" };
                manager.Create(role);
            }

            //Buitendienst account
            if (!context.Users.Any(u => u.UserName == "thijsvanbuitendienst@toolsforever.nl"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "thijsvanbuitendienst@toolsforever.nl" };

                manager.Create(user, "Password123!");
                manager.AddToRole(user.Id, "Buitendienst");
            }

            context.ProductDbSet.AddOrUpdate(x => x.ProductId,
                new Product() { ProductId = 1, Naam = "Bosch Accuboor", Type = "AB223", InkoopPrijs = 50, VerkoopPrijs = 60, MinimaalAantal = 5 },
                new Product() { ProductId = 2, Naam = "Black + Decker Hamer", Type = "HMMR213", InkoopPrijs = 25, VerkoopPrijs = 30, MinimaalAantal = 5 },
                new Product() { ProductId = 3, Naam = "Makita Boor", Type = "B00R1", InkoopPrijs = 74, VerkoopPrijs = 86, MinimaalAantal = 10 },
                new Product() { ProductId = 4, Naam = "Bosch Hamer", Type = "HMMR3", InkoopPrijs = 15, VerkoopPrijs = 30, MinimaalAantal = 20, }
                );

            context.ProductFabrikantDbSet.AddOrUpdate(x => x.ProductId,
               new ProductFabrikant_regel() { ProductId = 1, FabrikantId = 1, },
               new ProductFabrikant_regel() { ProductId = 2, FabrikantId = 2, },
               new ProductFabrikant_regel() { ProductId = 3, FabrikantId = 3, },
               new ProductFabrikant_regel() { ProductId = 4, FabrikantId = 1, }
               );

            context.LocatieDbSet.AddOrUpdate(x => x.LocatieId,
               new Locatie() { LocatieId = 1, Adres = "Eindhoofdweg 4", Postcode = "1790 AB", Plaats = "Eindhoven" },
               new Locatie() { LocatieId = 2, Adres = "Allemerenweg 7", Postcode = "1311 XD", Plaats = "Almere" },
               new Locatie() { LocatieId = 3, Adres = "Rotterdamselaan 899", Postcode = "2444 TK", Plaats = "Rotterdam" }
               );

            context.FabrikantDbSet.AddOrUpdate(x => x.FabrikantId,
                new Fabrikant() { FabrikantId = 1, Naam = "Bosch", Telefoonnummer = "0227-123456" },
                new Fabrikant() { FabrikantId = 2, Naam = "Black & Decker", Telefoonnummer = "0227-986322" },
                new Fabrikant() { FabrikantId = 3, Naam = "Makita", Telefoonnummer = "0241-544442" }
                );
        }
    }
}