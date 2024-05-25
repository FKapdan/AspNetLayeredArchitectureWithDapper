using Core.Abstracts;
using Core.Entities.Auth;
using Core.Entities.Results;
using Core.Extensions;
using Core.Utilities.Abstracts;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [ApiController]
    public class AuthController : BaseApiController
    {
        private readonly LayerAbstractBase<Users> _usersService;
        private readonly IJwtHelpler jwtHelpler;
        private readonly ILogger<AuthController> logger;
        public AuthController(LayerAbstractBase<Users> UsersService, IJwtHelpler JwtHelpler, ILogger<AuthController> Logger)
        {
            _usersService = UsersService;
            jwtHelpler = JwtHelpler;
            logger = Logger;
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginInput loginInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultBase(false, "Metot istek modeli hatalı, kontrol ediniz."));
            }
            var UserCheck = await _usersService.GetAsync(new Users() { Active = "T", UserName = loginInput.UserName, Password = loginInput.Password });
            if (UserCheck.Success && UserCheck.Data != null)
            {
                var Claims = new List<Claim>() {
                    new Claim(ClaimTypes.Name,loginInput.UserName)
                };

                return Ok(new DataResultBase<LoginOutput>(new LoginOutput() { Token = jwtHelpler.CreateToken(Claims) }));
            }
            logger.Log(LogLevel.Error, loginInput, UserCheck);
            return NotFound(new ResultBase(false, UserCheck.Message));
        }
        [HttpPost]
        public async Task<IActionResult> Auth2(LoginInput loginInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultBase(false, "Metot istek modeli hatalı, kontrol ediniz."));
            }
            var UserCheck = await _usersService.GetAsync(new Users() { Active = "T", UserName = loginInput.UserName, Password = loginInput.Password });
            if (UserCheck.Success && UserCheck.Data != null)
            {
                var Claims = new List<Claim>() {
                    new Claim(ClaimTypes.Name,loginInput.UserName)
                };

                return Ok(new DataResultBase<LoginOutput>(new LoginOutput() { Token = jwtHelpler.CreateToken(Claims) }));
            }
            logger.Log(LogLevel.Error, loginInput, UserCheck,"");
            return NotFound(new ResultBase(false, UserCheck.Message));
        }
    }
}
