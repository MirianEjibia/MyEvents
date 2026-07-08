using API.Middlwares;
using Core;
using FluentValidation;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using UseCases.Events.Queries;
using UseCases.Events.Validators;
using UseCases.Mappiggs;

var builder = WebApplication.CreateBuilder(args);

const string ClientCorsPolicy = "ClientCorsPolicy";


builder.Services.AddControllers(mvcOptions =>
{ 
    var authorizationPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    mvcOptions.Filters.Add(new AuthorizeFilter(authorizationPolicy));
});
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);
builder.Services.AddCors(options =>
{
    options.AddPolicy(ClientCorsPolicy, policy =>
    {
        policy.WithOrigins("https://localhost:5173", "https://localhost:5005")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});
builder.Services.AddMediatR(r => {
    r.RegisterServicesFromAssemblyContaining<GetEvents.Handler>();
    r.AddOpenBehavior(typeof(ValidationBehavior<,>));
    });
builder.Services.AddValidatorsFromAssemblyContaining<CreateEventValidator>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<ExceptionMiddleware>();
builder.Services.AddIdentityApiEndpoints<User>(opts => opts.User.RequireUniqueEmail = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseCors(ClientCorsPolicy);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGroup("api").MapIdentityApi<User>();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context =  services.GetRequiredService<ApplicationDbContext>();
    await context.Database.MigrateAsync();
    await DbInitializer.SeedData(context, services.GetRequiredService<UserManager<User>>());
}

app.Run();
