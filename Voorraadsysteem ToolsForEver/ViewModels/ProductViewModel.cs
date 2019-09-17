using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Voorraadsysteem_ToolsForEver.ViewModels
{
    public class ProductViewModel
    {
        [Display(Name = "Productnummer")]
        public int ProductId { get; set; }

        [Display(Name = "Productnaam")]
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

        [Display(Name = "Fabrikant")]
        [Required]
        public string FabrikantNaam { get; set; }

        [Display(Name = "Aantal")]
        [Required]
        public int Aantal { get; set; }

        public SelectList ProductFabrikant { get; set; }
        public List<int> FabrikantId { get; set; }
        public SelectList ProductLocatie { get; set; }
        public List<int> LocatieId { get; set; }
    }
}