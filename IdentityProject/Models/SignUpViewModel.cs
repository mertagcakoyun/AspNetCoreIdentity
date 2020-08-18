using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProject.Models
{
    public class SignUpViewModel
    {   
        [Display(Name="Username")]
        [Required(ErrorMessage =" Please enter your username")]
        public string UserName { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = " Please enter your name")]
        public string Name { get; set; }
        [Display(Name = "Surrname")]
        [Required(ErrorMessage = " Please enter your surname")]
        public string Surname { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = " Please enter your email")]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = " Please enter your password")]
        public string Password { get; set; }
        [Display(Name = "Password")]

        [Compare("Password",ErrorMessage ="Passwords did not match !")]
        public string ConfirmPassword { get; set; }
       
    }
}
