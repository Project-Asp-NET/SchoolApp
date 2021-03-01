using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Code Apoge")]
        public string IdEtud { get; set; }
        [Display(Name = "Filiere")]
        public string IdFill { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        [Display(Name = "Telephone")]
        public string Tel { get; set; }
        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateNaiss { get; set; }
        public string Adresse { get; set; }

        public virtual Filliere IdFillNavigation { get; set; }
        public virtual ICollection<Absence> Absences { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Validation> Validations { get; set; }
    }
}
