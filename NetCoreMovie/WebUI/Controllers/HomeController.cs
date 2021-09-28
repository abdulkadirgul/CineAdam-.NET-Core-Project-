using DataAccess.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;
using WebUI.Models.ViewModels;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> usermanager;
        private readonly SignInManager<AppUser> signInManager;

        public HomeController(UserManager<AppUser> _usermanager, SignInManager<AppUser> _signInManager)
        {
            usermanager = _usermanager;
            signInManager = _signInManager;
        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Users()
        {

            var users = usermanager.Users.ToList();
            return View(users);
        }

        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {

                AppUser newUser = new AppUser()
                {
                    UserName = registerVM.UserName,
                    Email = registerVM.Email
                };

                var result = await usermanager.CreateAsync(newUser, registerVM.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }


            }
            return View();
        }

        public IActionResult Login()
        {
            //TODO: Implement Realistic Implementation
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await usermanager.FindByEmailAsync(loginVM.Email);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return View("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("failedLogin", "Şifre Hatalı!");
                        return View();
                    }

                }
                else
                {
                    ModelState.AddModelError("notFound", "Böyle Bir Kullanıcı Bulunamadı!");
                    return View();
                }
            }
            else
                return View();
        }

    }
}
