using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SchoolApp.Models
{
    public partial class Module
    {
        public Module()
        {
            Elements = new HashSet<Element>();
            Validations = new HashSet<Validation>();
        }

        [Display(Name = "Module")]
        public string IdMod { get; set; }
        [Display(Name = "Filiere")]
        public string IdFill { get; set; }
        [Display(Name = "Nom Module")]
        public string NomMod { get; set; }
        public string Semestre { get; set; }

        public virtual Filliere IdFillNavigation { get; set; }
        public virtual ICollection<Element> Elements { get; set; }
        public virtual ICollection<Validation> Validations { get; set; }
    }
}
