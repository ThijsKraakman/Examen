using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Voorraadsysteem_ToolsForEver.ViewModels
{
    public class MedewerkerViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Gebruikersnaam (E-mailadres)")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord bevestigen")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Medewerkerscode")]
        [Required]
        public int MedewerkersCode { get; set; }

        [Display(Name = "Voorletters")]
        [Required]
        public string Voorletters { get; set; }

        [Display(Name = "Voorvoegsels")]
        public string Voorvoegsels { get; set; }

        [Display(Name = "Achternaam")]
        [Required]
        public string Achternaam { get; set; }

        [Display(Name = "Voornaam")]
        [Required]
        public string Naam { get; set; }
    }
}