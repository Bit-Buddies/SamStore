using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.WebAPI.Core.Identity.Claims
{
    public class CustomAuthorization
    {
        public static bool ValidateUserClaims(HttpContext httpContext, string claimName, string claimValue)
        {
            bool isAuthenticated = httpContext.User.Identity.IsAuthenticated;

            if (!isAuthenticated)
                return false;

            return httpContext.User.Claims.Any(c => c.Type == claimName && c.Value.Contains(claimValue));
        }
    }
}
