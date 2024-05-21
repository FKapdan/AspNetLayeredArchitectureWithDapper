using Core.Abstracts;
using Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Web.ViewModels;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly LayerAbstractBase<Users> _usersService;
        public LoginController(LayerAbstractBase<Users> UsersService)
        {
            _usersService = UsersService;
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
            var UserCheck = _usersService.Get(new Users() { Active = "T", UserName = LoginModel.UserName, Password = LoginModel.Password });
            if (UserCheck.Success && UserCheck.Data != null)
            {
                var Claims = new List<Claim>() {
                    new Claim(ClaimTypes.Name,LoginModel.UserName)
                };
                var CalimIdentity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var userPrincipal = new ClaimsPrincipal(CalimIdentity);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal).Wait();

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