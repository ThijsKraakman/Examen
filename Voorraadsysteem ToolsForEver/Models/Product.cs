using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Voorraadsysteem_ToolsForEver.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string Naam { get; set; }
        public string Type { get; set; }
        public double InkoopPrijs { get; set; }
        public double VerkoopPrijs { get; set; }
        public int MinimaalAantal { get; set; }

        public ICollection<ProductVoorraad_regel> VoorraadProduct { get; set; }
        public ICollection<ProductFabrikant_regel> ProductFabrikant { get; set; }

        public Product()
        {
        }

        public Product(string naam, string type, int minimaalAantal, double inkoopPrijs, double verkoopPrijs)
        {
            Naam = naam;
            Type = type;
            InkoopPrijs = inkoopPrijs;
            VerkoopPrijs = verkoopPrijs;
            MinimaalAantal = minimaalAantal;
            VoorraadProduct = new List<ProductVoorraad_regel>();
            ProductFabrikant = new List<ProductFabrikant_regel>();
        }
    }
}