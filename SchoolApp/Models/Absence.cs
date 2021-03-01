using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SchoolApp.Models
{
    public partial class Absence
    {
        [Display(Name = "Code")]
        public string IdEtud { get; set; }
        [Display(Name = "Element")]
        public string IdElem { get; set; }
        [Display(Name = "Date")]
        public DateTime? DateAbs { get; set; }
        public bool? IsJustif { get; set; }

        public string Justification { get; set; }

        public virtual Element IdElemNavigation { get; set; }
        public virtual Etudiant IdEtudNavigation { get; set; }
    }
}
