using System.Security.Claims;

namespace Core.Utilities.Abstracts
{
    public interface IJwtHelpler
    {
        string CreateToken(IEnumerable<Claim> claims);
        IEnumerable<Claim> ParseToken(string token);
        bool IsTokenExpired2(string token);
        bool IsTokenExpired(string token);
    }
}
