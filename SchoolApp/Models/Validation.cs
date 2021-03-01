using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SchoolApp.Models
{
    public partial class Validation
    {
        [Display(Name = "Code Apoge")]
        public string IdEtud { get; set; }
        [Display(Name = "Module")]
        public string IdMod { get; set; }
        [Display(Name = "Validation")]
        public string Validation1 { get; set; }
        [Display(Name = "Note Final")]
        public decimal? NoteFinal { get; set; }

        public virtual Etudiant IdEtudNavigation { get; set; }
        public virtual Module IdModNavigation { get; set; }
    }
}
