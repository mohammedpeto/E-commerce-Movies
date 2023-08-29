using eTickets.Data.ViewModels;
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
        public AccountController(UserManager<IdentityUser> _userManager , SignInManager<IdentityUser> _signInManager)
        {
            UserManager = _userManager;
            SignInManager = _signInManager;
        }

        public UserManager<IdentityUser> UserManager { get; }
        public SignInManager<IdentityUser> SignInManager { get; }

       

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterAccountViewModel reg)
        {
            if(ModelState.IsValid==true)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = reg.UserName;
                user.Email = reg.Email;
                IdentityResult result = await UserManager.CreateAsync(user, reg.Password);
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
                IdentityUser user = await UserManager.FindByNameAsync(logg.UserName);
                if(user !=null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await SignInManager.PasswordSignInAsync(user, logg.Password, false, false);
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
