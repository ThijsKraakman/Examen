using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Voorraadsysteem_ToolsForEver.Models
{
    public class Fabrikant
    {
        [Key]
        public int FabrikantId { get; set; }

        [Required]
        public string Naam { get; set; }

        [Required]
        public string Telefoonnummer { get; set; }

        public ICollection<ProductFabrikant_regel> ProductFabrikanten { get; set; }

        public Fabrikant()
        {
        }

        public Fabrikant(string naam, string telefoonnummer)
        {
            Naam = naam;
            Telefoonnummer = telefoonnummer;

            ProductFabrikanten = new List<ProductFabrikant_regel>();
        }
    }
}