using System.IdentityModel.Tokens.Jwt;

namespace NutriSportPro.API.Ressources;

public class UserFilterMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context, ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
    {
        if (context.Request.Headers.TryGetValue("Authorization", out var headerValues))
        {
            var token = headerValues.FirstOrDefault()?.Split(" ")[^1]; // Use indexing at Count-1 instead of Last()

            if (!string.IsNullOrEmpty(token))
            {
                var jwtHandler = new JwtSecurityTokenHandler();
                var jwtToken = jwtHandler.ReadJwtToken(token);

                var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "uid");
                if (userIdClaim != null)
                {
                    var userId = userIdClaim.Value;
                    dbContext.UserId = userId;
                }
            }
        }

        await _next(context);
    }
}
