using System.Security.Claims;

namespace NutriSportPro.API.Helpers;

public static class Helper
{
    public static string? GetConnectedUserId(ClaimsPrincipal user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        var userIdClaim = user.FindFirst("uid");
        return userIdClaim?.Value;
    }
}
