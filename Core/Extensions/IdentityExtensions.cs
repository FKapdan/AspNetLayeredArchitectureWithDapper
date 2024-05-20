using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Security.Claims;

namespace Core.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetWindowsAccountName(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.WindowsAccountName);
            return claim?.Value ?? string.Empty;
        }
        public static string GetEmail(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.Email);
            return claim?.Value ?? string.Empty;
        }
        public static string GetRoles(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.Role);
            return claim?.Value ?? string.Empty;
        }
        public static string GetGivenName(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.GivenName);
            return claim?.Value ?? string.Empty;
        }
        public static string GetUserData(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.UserData);
            return claim?.Value ?? string.Empty;
        }
        public static string GetMobilePhone(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.MobilePhone);
            return claim?.Value ?? string.Empty;
        }
        public static string GetBirthDate(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.DateOfBirth);
            return claim?.Value ?? string.Empty;
        }
        /// <summary>
        /// Custom eklenen Claim keyleri gönderilen key bilgine göre alınabilir.
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public static string GetByKey(this IIdentity identity, string Key)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(Key);
            return claim?.Value ?? string.Empty;
        }
    }
}
