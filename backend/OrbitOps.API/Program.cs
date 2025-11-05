
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using OrbitOps.API.Data;
using OrbitOps.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuration
var configuration = builder.Configuration;
var services = builder.Services;

// DbContext
var conn = configuration.GetConnectionString("Default") ?? 
           Environment.GetEnvironmentVariable("ConnectionStrings__Default") ??
           "Host=localhost;Database=orbit_db;Username=orbit;Password=orbitpass";
services.AddDbContext<AppDbContext>(options => options.UseNpgsql(conn));

// JWT Auth (basic setup)
var jwtSecret = configuration["JWT:Secret"] ?? Environment.GetEnvironmentVariable("JWT__Secret") ?? "ChangeThisSecret";
var key = Encoding.ASCII.GetBytes(jwtSecret);
services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

// DI for services/repositories
services.AddScoped<IClientService, ClientService>();
services.AddScoped<IProjectService, ProjectService>();

var app = builder.Build();

// Apply migrations automatically in dev (simple approach)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
