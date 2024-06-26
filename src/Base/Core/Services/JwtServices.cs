﻿using Core.Entities.Jwt;
using Core.Services.Abstracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Services
{
    public sealed class JwtServices : IJwtServices
    {
        private readonly JwtOptions jwtOptions;
        public JwtServices(IConfiguration Configuration)
        {
            jwtOptions = Configuration.GetSection("JwtOptions").Get<JwtOptions>();
        }
        public string CreateToken(IEnumerable<Claim> claims)
        {
            var credentials = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key));
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(jwtOptions.TokenExpireTime),
                SigningCredentials = new SigningCredentials(credentials, SecurityAlgorithms.HmacSha256Signature),
                Issuer = jwtOptions.Issuer,
                Audience = jwtOptions.Audience
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(securityTokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public IEnumerable<Claim> ParseToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key)),
                ValidateLifetime = false, // Not required for parsing, can be adjusted
                ValidateIssuer = false,
                ValidateAudience = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
            return securityToken.Claims;
        }
        public bool IsTokenExpired(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key)),
                ValidateLifetime = true,
                ValidateIssuer = false,
                ValidateAudience = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadJwtToken(token);
            return securityToken.ValidTo < DateTime.UtcNow;
        }
        public bool IsTokenExpired2(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            if (jwtToken == null)
                return true;

            return jwtToken.ValidTo <= DateTime.UtcNow;
        }
    }
}
