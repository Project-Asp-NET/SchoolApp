using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SchoolApp.Models
{
    public partial class Filliere
    {
        public Filliere()
        {
            Etudiants = new HashSet<Etudiant>();
            Modules = new HashSet<Module>();
        }

        [Display(Name = "Filiere")]
        public string IdFill { get; set; }

        [Display(Name = "Prof")]
        public string IdProf { get; set; }
        [Display(Name = "Nom Filiere")]
        public string NomFill { get; set; }

        public virtual Prof IdProfNavigation { get; set; }
        public virtual ICollection<Etudiant> Etudiants { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
    }
}
