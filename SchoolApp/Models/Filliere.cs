using System;
using System.Collections.Generic;

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

        public string IdFill { get; set; }
        public string IdProf { get; set; }
        public string NomFill { get; set; }

        public virtual Prof IdProfNavigation { get; set; }
        public virtual ICollection<Etudiant> Etudiants { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
    }
}
