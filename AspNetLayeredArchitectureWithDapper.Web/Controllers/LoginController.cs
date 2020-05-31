using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetLayeredArchitectureWithDapper.Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace AspNetLayeredArchitectureWithDapper.Web.Controllers
{
    public class LoginController : Controller
    {
        List<LoginViewModel> _UserList { get; set; }
        List<LoginViewModel> UserList
        {
            get
            {
                if (_UserList == null)
                {
                    _UserList = new List<LoginViewModel>() {
                    new LoginViewModel(){UserName="Captain1",Password="cp125*" },
                    new LoginViewModel(){UserName="Captain2",Password="cp532-" },
                    new LoginViewModel(){UserName="Captain3",Password="cp567_" }
                    };
                }
                return _UserList;
            }
        }
        public IActionResult Index(string returnUrl)
        {
            return View(new LoginViewModel() { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public IActionResult Index(LoginViewModel LoginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(LoginModel);
            }

            if (UserList.Any(x => x.UserName == LoginModel.UserName && x.Password == LoginModel.Password))
            {
                var Claims = new List<Claim>() {
                    new Claim(ClaimTypes.Name,LoginModel.UserName)
                };
                var CalimIdentity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var userPrincipal = new ClaimsPrincipal(CalimIdentity);

                HttpContext.SignInAsync(userPrincipal);

                if (string.IsNullOrEmpty(LoginModel.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Redirect(LoginModel.ReturnUrl);
                }
            }
            ModelState.AddModelError("", "Username/Password not found!");
            return View(LoginModel);
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}