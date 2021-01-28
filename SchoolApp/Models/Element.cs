using System;
using System.Collections.Generic;

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

        public string IdElem { get; set; }
        public string IdMod { get; set; }
        public string IdProf { get; set; }
        public string NomElem { get; set; }

        public virtual Module IdModNavigation { get; set; }
        public virtual Prof IdProfNavigation { get; set; }
        public virtual ICollection<Absence> Absences { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
