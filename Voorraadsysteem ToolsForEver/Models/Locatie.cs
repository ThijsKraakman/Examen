using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Voorraadsysteem_ToolsForEver.Models
{
    public class Locatie
    {
        [Key]
        public int LocatieId { get; set; }

        [Required]
        public string Adres { get; set; }

        [Required]
        public string Postcode { get; set; }

        [Required]
        public string Plaats { get; set; }

        public ICollection<ProductLocatie_regel> ProductLocaties { get; set; }

        public Locatie()
        {
        }

        public Locatie(string adres, string postcode, string plaats)
        {
            Adres = adres;
            Postcode = postcode;
            Plaats = plaats;
            ProductLocaties = new List<ProductLocatie_regel>();
        }
    }
}