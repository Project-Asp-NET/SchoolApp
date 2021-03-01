using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SchoolApp.Models
{
    public partial class Note
    {
        [Display(Name = "Code Apoge")]
        public string IdEtud { get; set; }
        [Display(Name = "Element")]
        public string IdElem { get; set; }
        [Display(Name = "Note")]
        public decimal? NoteAvRatt { get; set; }
        [Display(Name = "Note Ratt")]
        public decimal? NoteRatt { get; set; }
        [Display(Name = "Note Final")]
        public decimal? NoteFinal { get; set; }

        public virtual Element IdElemNavigation { get; set; }
        public virtual Etudiant IdEtudNavigation { get; set; }
    }
}
