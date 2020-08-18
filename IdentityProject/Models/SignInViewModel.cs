using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProject.Models
{
    public class SignInViewModel
    {
        [Display(Name = "* Username: ")]
        [Required(ErrorMessage = "Please Enter Username! ")]
        public string UserName { get; set; }

        [Display(Name = "* Password: ")]
        [Required(ErrorMessage = "Please Enter Password! ")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
