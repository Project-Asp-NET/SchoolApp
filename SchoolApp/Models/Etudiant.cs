using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SchoolApp.Models
{
    public partial class Etudiant
    {
        [Display(Name = "Code")]
        public string IdEtud { get; set; }
        [Display(Name = "Filliere")]
        public string IdFill { get; set; }
        public string Password { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        [Display(Name = "Telephone")]
        public string Tel { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Naissance")]
        public DateTime? DateNaiss { get; set; }
        public string Adresse { get; set; }
    }
}
