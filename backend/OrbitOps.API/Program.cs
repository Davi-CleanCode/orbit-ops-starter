using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using OrbitOps.API.Data;
using OrbitOps.API.Services;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var services = builder.Services;

// ======================================================
// DATABASE (PostgreSQL)
// ======================================================
var conn = configuration.GetConnectionString("Default") ??
           Environment.GetEnvironmentVariable("ConnectionStrings__Default") ??
           "Host=localhost;Database=orbit_db;Username=orbit;Password=orbitpass";

services.AddDbContext<AppDbContext>(options => options.UseNpgsql(conn));

// ======================================================
// JWT AUTHENTICATION
// ======================================================
var jwtSecret = configuration["JWT:Secret"] ??
                Environment.GetEnvironmentVariable("JWT__Secret") ??
                "ChangeThisSecret";

var key = Encoding.ASCII.GetBytes(jwtSecret);

services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true
    };
});

// ======================================================
// CORS (LIBERAR FRONTEND NEXT.JS)
// ======================================================
services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .WithOrigins("http://localhost:3000", "http://127.0.0.1:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

// ======================================================
// SWAGGER + JWT SUPPORT
// ======================================================
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "OrbitOps CRM API",
        Version = "v1",
        Description = "API do CRM OrbitOps, criada em ASP.NET Core."
    });

    // JWT no Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Digite abaixo: Bearer {seu_token_jwt}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// ======================================================
// DEPENDENCY INJECTION (SERVICES)
// ======================================================
services.AddScoped<IClientService, ClientService>();
services.AddScoped<IProjectService, ProjectService>();

services.AddControllers();

var app = builder.Build();

// ======================================================
// DATABASE MIGRATIONS AUTOMÁTICAS
// ======================================================
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate(); // IMPORTANTE: usa as migrations reais
}

// ======================================================
// MIDDLEWARE PIPELINE
// ======================================================
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrbitOps CRM API");
        c.RoutePrefix = string.Empty; // Swagger na raiz do site
    });
}

app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
