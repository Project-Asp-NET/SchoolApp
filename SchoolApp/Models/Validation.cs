using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolApp.Models
{
    public partial class Validation
    {
        public string IdEtud { get; set; }
        public string IdMod { get; set; }
        public string Valid { get; set; }
        public decimal? NoteFinal { get; set; }
    }
}
