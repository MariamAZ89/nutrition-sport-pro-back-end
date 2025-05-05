using NutriSportPro.API.Dtos;
using NutriSportPro.API.Responses;

namespace NutriSportPro.API.Services.Contratcs;

public interface IAuthService
{
    Task<LoginResponse> GetTokenAsync(LoginRequest model);
}
