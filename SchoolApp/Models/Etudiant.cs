using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolApp.Models
{
    public partial class Etudiant
    {
        public string IdEtud { get; set; }
        public string IdFill { get; set; }
        public string Password { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public DateTime? DateNaiss { get; set; }
        public string Adresse { get; set; }
        public byte[] Photo { get; set; }
    }
}
