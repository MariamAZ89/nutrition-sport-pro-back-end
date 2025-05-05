using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NutriSportPro.API.Ressources;
using System.Text;

namespace NutriSportPro.API;

public static class AppContainer
{
    public static IServiceCollection AddAppContainer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            var connetcionString = configuration.GetConnectionString("DefaultConnection");
            ArgumentNullException.ThrowIfNull(connetcionString);
            options.UseSqlServer(connetcionString);
        });

        services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = false;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]!)),
                ValidateIssuer = true,
                ValidIssuer = configuration["JwtSettings:Issuer"],
                ValidateAudience = true,
                ValidAudience = configuration["JwtSettings:Audience"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

        });

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAsyncService<object>, AsyncService<object>>();
        services.AddScoped<ITrainingService, TrainingService>();
        services.AddScoped<ITrainingPlanService, TrainingPlanService>();
        services.AddScoped<IStatisticService, StatisticService>();
        services.AddScoped<ISportsProfileService, SportsProfileService>();
        services.AddScoped<IExerciseService, ExerciseService>();
        services.AddScoped<IChatCoachService, ChatCoachService>();
        services.AddScoped<ICoachProfileService, CoachProfileService>();
        services.AddScoped<IFoodProgramService, FoodProgramService>();
        services.AddScoped<INutritionService, NutritionService>();

        return services;
    }
}
