using Core.Abstracts;
using Core.Entities.Auth;
using Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Core.Utilities.Abstracts;
using Core.Entities.Results;
using Core.Extensions;

namespace Api.Controllers
{
    [Route("api/[controller]")]
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
            logger.LogSuccess(LogLevel.Error, loginInput, UserCheck);
            return NotFound(new ResultBase(false, UserCheck.Message));
        }
    }
}
