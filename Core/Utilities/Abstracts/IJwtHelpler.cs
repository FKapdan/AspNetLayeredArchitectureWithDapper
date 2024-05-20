using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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
