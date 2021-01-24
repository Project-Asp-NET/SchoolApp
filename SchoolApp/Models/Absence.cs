using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolApp.Models
{
    public partial class Absence
    {
        public string IdEtud { get; set; }
        public string IdElem { get; set; }
        public DateTime? DateAbs { get; set; }
        public bool? IsJustif { get; set; }
        public string Justification { get; set; }
    }
}
