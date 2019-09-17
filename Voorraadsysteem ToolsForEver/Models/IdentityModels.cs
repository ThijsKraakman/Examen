using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Voorraadsysteem_ToolsForEver.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public int MedewerkersCode { get; set; }
        public string Voorletters { get; set; }
        public string Voorvoegsels { get; set; }
        public string Achternaam { get; set; }
        public string Naam { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Fabrikant> FabrikantDbSet { get; set; }
        public DbSet<Locatie> LocatieDbSet { get; set; }
        public DbSet<Product> ProductDbSet { get; set; }
        public DbSet<Voorraad> VoorraadDbSet { get; set; }
        public DbSet<ProductFabrikant_regel> ProductFabrikantDbSet { get; set; }
        public DbSet<ProductLocatie_regel> ProductLocatieDbSet { get; set; }
        public DbSet<ProductVoorraad_regel> ProductVoorraadDbSet { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}