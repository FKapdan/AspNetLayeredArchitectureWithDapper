using Core.Entities.Results;
using Core.Extensions;
using Core.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Core.Attributes.Authorize
{
    public sealed class ApiAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _requiredRoles;
        public ApiAuthorizeAttribute(params string[] requiredRoles)
        {
            _requiredRoles = requiredRoles;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tokenservice = (IJwtServices)context.HttpContext.RequestServices.GetService(typeof(IJwtServices));
            var authHeaderValue = context.HttpContext.GetHeaderValueByKey("Authorization");

            if (string.IsNullOrEmpty(authHeaderValue) || !authHeaderValue.StartsWith("Bearer "))
            {
                context.Result = new UnauthorizedObjectResult(new ResultBase("Header bilgisinde Bearer token bilgisi eksik"));
                return;
            }

            var token = authHeaderValue.Substring("Bearer ".Length).Trim();

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedObjectResult(new ResultBase("Header bilgisinde token bilgisi eksik"));
                return;
            }

            if (tokenservice.IsTokenExpired(token))
            {
                context.Result = new UnauthorizedObjectResult(new ResultBase("Token süresi dolu. Lütfen tekrar token alın."));
                return;
            }

            if (_requiredRoles.Any() && !HasRequiredRoles(tokenservice.ParseToken(context.HttpContext.User.Identity.GetByKey("Token"))))
            {
                context.Result = new UnauthorizedObjectResult(new ResultBase("Yetkisim erişim isteği."));
            }
        }
        public bool HasRequiredRoles(IEnumerable<Claim> claims)
        {
            return _requiredRoles.Any(role => claims.Any(claim => claim.Type == ClaimTypes.Role && (claim.Value?.Split(",")?.Any(r => r == role) ?? false)));
        }
    }
}
