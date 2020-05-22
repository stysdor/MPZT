using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MPZT.GUI.Models
{
    public class LoginView
    {
        [Required(ErrorMessage ="Pole jest wymagane")]
        [Display(Name = "Login")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Hasło")]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

    }

    public class CustomSerializeModel
    {
        public List<string> RoleName { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}