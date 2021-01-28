using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolApp.Models
{
    public partial class Note
    {
        public string IdEtud { get; set; }
        public string IdElem { get; set; }
        public decimal? NoteAvRatt { get; set; }
        public decimal? NoteRatt { get; set; }
        public decimal? NoteFinal { get; set; }

        public virtual Element IdElemNavigation { get; set; }
        public virtual Etudiant IdEtudNavigation { get; set; }
    }
}
