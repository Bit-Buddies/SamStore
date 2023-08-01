using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace SamStore.WebAPI.Core.Context
{
    public interface IHttpContextHandler
    {
        Guid GetUserId();
        string GetUserEmail();
        bool IsAuthenticated();
        bool hasRole(string role);
        IEnumerable<Claim> GetClaims();
        HttpContext GetHttpContext();
    }
}
