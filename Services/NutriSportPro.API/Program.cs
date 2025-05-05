using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using NutriSportPro.API;
using NutriSportPro.API.Ressources;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.EnableEndpointRouting = false;
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.AddOpenApi();

builder.Services.AddAppContainer(builder.Configuration);

builder.Services.AddCors(c =>
{
    c.AddPolicy("CorsPolicy", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Exceptions
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");

app.UseMiddleware<UserFilterMiddleware>();

// Init Data (User & Roles)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    ArgumentNullException.ThrowIfNull(dbContext);

    if ((await dbContext.Database.GetAppliedMigrationsAsync()).Any())
    {
        await dbContext.Database.MigrateAsync();
    }
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    ArgumentNullException.ThrowIfNull(userManager);
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
    ArgumentNullException.ThrowIfNull(roleManager);

    Dictionary<string, string> roles = new Dictionary<string, string>()
    {
        { "Administrator", "The administrator responsible for managing the application." },
        { "Coach", "The coach who provides guidance and support within the application." },
        { "SampleUser", "A sample user for demonstration purposes." }
    };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role.Key))
        {
            var identityRole = new ApplicationRole
            {
                Name = role.Key,
                NormalizedName = role.Key.ToUpper(),
                Description = role.Value,
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };
            await roleManager.CreateAsync(identityRole);
        }
    }
    string email = "admin@NutriSportPro.com";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new ApplicationUser
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            FirstName = "Admin",
            LastName = "Admin",
        };
        var result = await userManager.CreateAsync(user, "Admin@123");
        if (result.Succeeded)
        {
            var resultRole = await userManager.AddToRoleAsync(user, "Administrator");
            if (!resultRole.Succeeded)
            {
                throw new ArgumentNullException($"Failed to add user to role: {string.Join(", ", resultRole.Errors.Select(e => e.Description))}");
            }
        }
        else
        {
            throw new ArgumentNullException($"Failed to create user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }
}
await app.RunAsync();
