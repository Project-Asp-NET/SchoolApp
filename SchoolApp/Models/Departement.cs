using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolApp.Models
{
    public partial class Departement
    {
        public Departement()
        {
            Profs = new HashSet<Prof>();
        }

        public string IdDep { get; set; }
        public string NomDep { get; set; }

        public virtual ICollection<Prof> Profs { get; set; }
    }
}
