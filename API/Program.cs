using Infrastructure;
using Microsoft.EntityFrameworkCore;
using UseCases.Events.Queries;
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
        policy.WithOrigins("https://localhost:5005")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddMediatR(r => r.RegisterServicesFromAssemblyContaining<GetEvents.Handler>());

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

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
