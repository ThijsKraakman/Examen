using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Voorraadsysteem_ToolsForEver.Models;

namespace Voorraadsysteem_ToolsForEver.ViewModels
{
    public class VoorraadViewModel
    {
        [Display(Name = "Voorraadnummer")]
        public int VoorraadItemId { get; set; }

        [Display(Name = "Aantal")]
        [Required]
        public int Aantal { get; set; }

        [Display(Name = "Product")]
        [Required]
        public string Naam { get; set; }

        [Display(Name = "Producttype")]
        [Required]
        public string Type { get; set; }

        [Display(Name = "Minimaal aantal")]
        [Required]
        public int MinimaalAantal { get; set; }

        [Display(Name = "Inkoopprijs in €")]
        [Required]
        public double InkoopPrijs { get; set; }

        [Display(Name = "Verkoopprijs in €")]
        [Required]
        public double VerkoopPrijs { get; set; }

        [Display(Name = "Locatie")]
        [Required]
        public string Plaats { get; set; }

        public SelectList ProductLocatie { get; set; }
        public List<int> LocatieId { get; set; }
        public SelectList VoorraadProduct { get; set; }
        public List<int> ProductId { get; set; }

        public List<Locatie> ConnectedLocaties { get; set; }
        public List<Product> ConnectedProducts { get; set; }
    }
}