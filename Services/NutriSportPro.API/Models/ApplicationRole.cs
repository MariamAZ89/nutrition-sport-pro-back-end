namespace NutriSportPro.API.Models;

public class ApplicationRole : IdentityRole
{
    public required string Description { get; set; }
}
