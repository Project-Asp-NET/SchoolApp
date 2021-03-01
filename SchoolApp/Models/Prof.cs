using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SchoolApp.Models
{
    public partial class Prof
    {
        public Prof()
        {
            Elements = new HashSet<Element>();
        }
        [Display(Name = "Prof")]
        public string IdProf { get; set; }
        [Display(Name = "Departement")]
        public string IdDep { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Nom")]
        public string Nom { get; set; }
        [Display(Name = "Prenom")]
        public string Prenom { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Telephone")]
        public string Tel { get; set; }
        [Display(Name = "Filiere")]
        public string IdFill { get; set; }

        public virtual Departement IdDepNavigation { get; set; }
        public virtual Filliere IdFillNavigation { get; set; }
        public virtual ICollection<Element> Elements { get; set; }
    }
}
