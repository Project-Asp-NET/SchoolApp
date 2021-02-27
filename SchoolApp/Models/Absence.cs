using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SchoolApp.Models
{
    public partial class Absence
    {
        public string IdEtud { get; set; }
        public string IdElem { get; set; }
        
        [Display(Name = "Date d'absence")]
        public DateTime? DateAbs { get; set; }

        [Display(Name = "Absence justifiée")]
        public bool? IsJustif { get; set; }

        public string Justification { get; set; }

        public virtual Element IdElemNavigation { get; set; }
        public virtual Etudiant IdEtudNavigation { get; set; }
    }
}
