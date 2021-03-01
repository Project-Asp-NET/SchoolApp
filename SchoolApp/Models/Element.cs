using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SchoolApp.Models
{
    public partial class Element
    {
        public Element()
        {
            Absences = new HashSet<Absence>();
            Notes = new HashSet<Note>();
        }

        [Display(Name = "Element")]
        public string IdElem { get; set; }
        [Display(Name = "Module")]
        public string IdMod { get; set; }
        [Display(Name = "Code Prof")]
        public string IdProf { get; set; }
        [Display(Name = "Nom Element")]
        public string NomElem { get; set; }

        public virtual Module IdModNavigation { get; set; }
        public virtual Prof IdProfNavigation { get; set; }
        public virtual ICollection<Absence> Absences { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
