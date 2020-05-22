using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MPZT.GUI.Models
{
    public class Registration
    {
        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Imię")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Nie prawidłowy adres email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Hasło")]
        [StringLength(255, ErrorMessage = "Hasło musi zawierać pomiędzy 8 a 255 znaków", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Potwierdź hasło")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Hasła muszą być identyczne")]
        public string ConfirmedPassword { get; set; }



    }
}