using API.Middlwares;
using Core;
using FluentValidation;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using UseCases.Events.Queries;
using UseCases.Events.Validators;
using UseCases.Mappiggs;

var builder = WebApplication.CreateBuilder(args);

const string ClientCorsPolicy = "ClientCorsPolicy";

// Add services to the container.

builder.Services.AddControllers();
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

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseCors(ClientCorsPolicy);

app.MapControllers();

// seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context =  services.GetRequiredService<ApplicationDbContext>();
    await context.Database.MigrateAsync();
    await DbInitializer.SeedData(context);
}

app.Run();
