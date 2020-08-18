using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityProject.Context;
using IdentityProject.Models;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityProject.Controllers
{
    public class HomeController : Controller
    {
        //Dependency Inversion Sağlanması
        // User Manager örneği üzerinden ilgili classın constructor'ında _userManager ı görünce user managerin örneğini fırlatacak
        // startupta identity yi programa eklediğimiz için halihazırda identity frameworkün içindeki container aracılığıyla örnekleme işlemini yapar.
        
        private readonly UserManager<AppUser> _userManager;
        public HomeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(new SignInViewModel());
        }

        [HttpPost]
        public IActionResult SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View("Index" , model);
        }

    public IActionResult SignUp()
        {

            return View(new SignUpViewModel());
        }

        [HttpPost]
        public async Task< IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser {
                    Name = model.Name,
                    Surname=model.Surname,
                    UserName=model.UserName,
                    Email = model.Email
            };
                var result= await _userManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View("Index");
        }
    }
}
