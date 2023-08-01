using System.Security.Claims;

public static class ContextUserExtensions
{
    public static string GetUserId(this ClaimsPrincipal principal)
    {
        if(principal == null)
            throw new ArgumentNullException(nameof(principal));

        Claim? claim = principal.FindFirst(ClaimTypes.NameIdentifier);

        return claim?.Value;
    }

    public static string GetUserEmail(this ClaimsPrincipal principal)
    {
        if(principal == null)
            throw new ArgumentNullException(nameof(principal));

        Claim? claim = principal.FindFirst(ClaimTypes.Email);
        return claim?.Value;
    }
}
