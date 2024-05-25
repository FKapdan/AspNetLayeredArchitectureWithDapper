using Core.Abstracts;
using Core.Entities.Auth;
using Core.Entities.Results;
using Core.Extensions;
using Core.Services.Abstracts;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly LayerAbstractBase<Users> _usersService;
        private readonly IJwtServices jwtServices;
        private readonly ILogger<AuthController> logger;
        public AuthController(
            LayerAbstractBase<Users> UsersService,
            IJwtServices JwtServices,
            ILogger<AuthController> Logger
            )
        {
            _usersService = UsersService;
            jwtServices = JwtServices;
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

                return Ok(new DataResultBase<LoginOutput>(new LoginOutput() { Token = jwtServices.CreateToken(Claims) }, UserCheck.Success));
            }
            logger.Log(LogLevel.Error, loginInput, UserCheck);
            return NotFound(new ResultBase(false, UserCheck.Message));
        }
    }
}
