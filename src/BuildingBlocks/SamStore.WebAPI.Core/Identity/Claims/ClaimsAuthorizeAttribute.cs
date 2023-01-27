using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SamStore.WebAPI.Core.Identity.Claims
{
    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimName, string claimValue) : base(typeof(RequiredClaimFilter))
        {
            Arguments = new object[] { new Claim(claimName, claimValue) };
        }
    }
}
