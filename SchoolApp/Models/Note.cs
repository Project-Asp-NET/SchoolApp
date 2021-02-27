using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SchoolApp.Models
{
    public partial class Note
    {
        public string IdEtud { get; set; }
        public string IdElem { get; set; }

        [Display(Name="Note avant rattrappage")]
        public decimal? NoteAvRatt { get; set; }

        [Display(Name="Note rattrappage")]
        public decimal? NoteRatt { get; set; }

        [Display(Name="Note Finale")]
        public decimal? NoteFinal { get; set; }

        public virtual Element IdElemNavigation { get; set; }
        public virtual Etudiant IdEtudNavigation { get; set; }
    }
}
