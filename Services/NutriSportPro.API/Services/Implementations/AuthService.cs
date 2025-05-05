using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NutriSportPro.API.Dtos;
using NutriSportPro.API.Responses;
using NutriSportPro.API.Ressources;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NutriSportPro.API.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly JwtSettings _jwtSettings;


    public AuthService(UserManager<ApplicationUser> userManager, IOptions<JwtSettings> options)
    {
        _userManager = userManager;
        _jwtSettings = options.Value;
    }
    public async Task<LoginResponse> GetTokenAsync(LoginRequest model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null || !(await _userManager.CheckPasswordAsync(user, model.Password)))
        {
            return new LoginResponse { IsAuthenticated = false, Message = "Invalid email or password.", Email = model.Email };
        }
        var jwtSecurityToken = await CreateJwtToken(user);
        var roleList = await _userManager.GetRolesAsync(user);

        return new LoginResponse
        {
            IsAuthenticated = true,
            Message = "Token generated successfully.",
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            ExpiresAt = jwtSecurityToken.ValidTo,
            UserId = user.Id,
            Email = user.Email!,
            Roles = roleList.ToList()
        };
    }
    private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);
        var roleClaims = new List<Claim>();
        foreach (var role in roles)
        {
            roleClaims.Add(new Claim("roles", role));
        }
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim("uid", user.Id),
        }.Union(roleClaims).Union(userClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials: signingCredentials
        );
        return jwtSecurityToken;
    }

}
