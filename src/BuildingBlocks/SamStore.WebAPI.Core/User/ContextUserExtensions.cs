﻿using System.Security.Claims;

public static class ContextUserExtensions
{
    public static string GetUserId(this ClaimsPrincipal principal)
    {
        if(principal == null)
            throw new ArgumentNullException(nameof(principal));

        Claim? claim = principal.FindFirst(ClaimTypes.NameIdentifier);

        if(claim == null)
            claim = principal.FindFirst("sub");

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
