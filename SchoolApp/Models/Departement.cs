using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SchoolApp.Models
{
    public partial class Departement
    {
        public Departement()
        {
            Profs = new HashSet<Prof>();
        }

        [Display(Name = "Code Departement")]
        public string IdDep { get; set; }
        [Display(Name = "Nom Departement")]
        public string NomDep { get; set; }

        public virtual ICollection<Prof> Profs { get; set; }
    }
}
