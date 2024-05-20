﻿using AspNetLayeredArchitectureWithDapper.Core.Results;
using Core.Extensions;
using Core.Utilities.Abstracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Attributes.Authorize
{
    public sealed class WebAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _requiredRoles;
        public WebAuthorizeAttribute(params string[] requiredRoles)
        {
            _requiredRoles = requiredRoles;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity?.IsAuthenticated ?? false)
            {
                context.HttpContext.Response.StatusCode = 401;
                if (context.HttpContext.Request.Headers["X-Requested-Width"] == "XMLHttpRequest")
                {
                    context.Result = new JsonResult(new DataResultBase<string>("Login", false));
                }
                else
                {
                    context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
                    context.HttpContext.Response.Redirect("/Login");
                }
                return;
            }
            var jwtHelper = (IJwtHelpler)context.HttpContext.RequestServices.GetService(typeof(IJwtHelpler));
            if (_requiredRoles.Any() && !HasRequiredRoles(jwtHelper.ParseToken(context.HttpContext.User.Identity.GetByKey("Token"))))
            {
                context.Result = new UnauthorizedResult();
            }
        }
        public bool HasRequiredRoles(IEnumerable<Claim> claims)
        {
            return _requiredRoles.Any(role => claims.Any(claim => claim.Type == ClaimTypes.Role && (claim.Value?.Split(",")?.Any(r => r == role) ?? false)));
        }
    }
}