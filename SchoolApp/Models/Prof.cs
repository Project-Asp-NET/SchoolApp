using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolApp.Models
{
    public partial class Prof
    {
        public Prof()
        {
            Elements = new HashSet<Element>();
        }

        public string IdProf { get; set; }
        public string IdDep { get; set; }
        public string Password { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string IdFill { get; set; }

        public virtual Departement IdDepNavigation { get; set; }
        public virtual Filliere IdFillNavigation { get; set; }
        public virtual ICollection<Element> Elements { get; set; }
    }
}
