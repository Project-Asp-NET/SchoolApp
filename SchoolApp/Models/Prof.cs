using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolApp.Models
{
    public partial class Prof
    {
        public string IdProf { get; set; }
        public string IdDep { get; set; }
        public string Password { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
    }
}
