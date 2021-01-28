using System;
using System.Collections.Generic;

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

        public string IdMod { get; set; }
        public string IdFill { get; set; }
        public string NomMod { get; set; }
        public string Semestre { get; set; }

        public virtual Filliere IdFillNavigation { get; set; }
        public virtual ICollection<Element> Elements { get; set; }
        public virtual ICollection<Validation> Validations { get; set; }
    }
}
