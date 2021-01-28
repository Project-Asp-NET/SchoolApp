using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolApp.Models
{
    public partial class Validation
    {
        public string IdEtud { get; set; }
        public string IdMod { get; set; }
        public string Validation1 { get; set; }
        public decimal? NoteFinal { get; set; }

        public virtual Etudiant IdEtudNavigation { get; set; }
        public virtual Module IdModNavigation { get; set; }
    }
}
