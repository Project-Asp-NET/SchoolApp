using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SchoolApp.Models
{
    public partial class Admin
    {
        [Display(Name = "Code Admin")]
        public string IdAdmin { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
