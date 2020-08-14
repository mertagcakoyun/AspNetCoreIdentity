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
        private readonly UserManager<AppUser> _userManager;
        public HomeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View(new SignInViewModel());
        }
        public IActionResult SignUp()
        {

            return View(new SignUpViewModel());
        }
        [HttpPost]
        public async Task< IActionResult> KayıtOl(SignUpViewModel model)
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
            return View();
        }
    }
}
