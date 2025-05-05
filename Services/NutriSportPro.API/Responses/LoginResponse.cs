namespace NutriSportPro.API.Responses;

public class LoginResponse
{
    public bool IsAuthenticated { get; set; } = false;
    public required string Message { get; set; }
    public string? Token { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public string? UserId { get; set; }
    public required string Email { get; set; }
    public List<string> Roles { get; set; } = new();
}
