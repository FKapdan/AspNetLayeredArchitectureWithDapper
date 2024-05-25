using System.Security.Claims;

namespace Core.Services.Abstracts
{
    public interface IJwtServices
    {
        string CreateToken(IEnumerable<Claim> claims);
        IEnumerable<Claim> ParseToken(string token);
        bool IsTokenExpired2(string token);
        bool IsTokenExpired(string token);
    }
}
