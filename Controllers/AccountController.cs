using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(UserManager<ApplicationUser> _userManager , SignInManager<ApplicationUser> _signInManager)
        {
            UserManager = _userManager;
            SignInManager = _signInManager;
        }

        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }

       

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterAccountViewModel reg)
        {
            if(ModelState.IsValid==true)
            {
                var user = new ApplicationUser();
                user.UserName = reg.UserName;
                user.Email = reg.Email;
                var result = await UserManager.CreateAsync(user, reg.Password);
                if(result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Movie");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel logg)
        {
            if(ModelState.IsValid == true)
            {
                ApplicationUser user = await UserManager.FindByNameAsync(logg.UserName);
                if(user !=null)
                {
                   var result = await SignInManager.PasswordSignInAsync(user, logg.Password, false, false);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movie");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Errproror");
                    }
                    ModelState.AddModelError("", "Errproror");
                }
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
