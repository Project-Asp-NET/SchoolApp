using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolApp.Models
{
    public partial class Etudiant
    {
        public Etudiant()
        {
            Absences = new HashSet<Absence>();
            Notes = new HashSet<Note>();
            Validations = new HashSet<Validation>();
        }

        public string IdEtud { get; set; }
        public string IdFill { get; set; }
        public string Password { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public DateTime? DateNaiss { get; set; }
        public string Adresse { get; set; }

        public virtual Filliere IdFillNavigation { get; set; }
        public virtual ICollection<Absence> Absences { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Validation> Validations { get; set; }
    }
}
