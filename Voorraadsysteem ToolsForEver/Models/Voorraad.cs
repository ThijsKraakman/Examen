using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Voorraadsysteem_ToolsForEver.Models
{
    public class Voorraad
    {
        [Key]
        public int VoorraadItemId { get; set; }

        public ICollection<ProductVoorraad_regel> VoorraadProduct { get; set; }
        public ICollection<ProductLocatie_regel> LocatieProduct { get; set; }

        public Voorraad()
        {
            VoorraadProduct = new List<ProductVoorraad_regel>();
            LocatieProduct = new List<ProductLocatie_regel>();
        }
    }
}