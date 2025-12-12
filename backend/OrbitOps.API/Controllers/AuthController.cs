using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrbitOps.API.Data;
using OrbitOps.API.DTOs;
using OrbitOps.API.Models;
using OrbitOps.API.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OrbitOps.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _config;

    public AuthController(AppDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    // REGISTER
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        if (await _context.Users.AnyAsync(u => u.Username == dto.Username))
            return BadRequest("Usuário já existe.");

        var user = new User
        {
            Username = dto.Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Role = dto.Role
        };

        PermissionMap.ApplyRolePermissions(user);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok("Usuário criado com sucesso.");
    }

    // LOGIN
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == dto.Username);

        if (user == null) return BadRequest("Usuário não encontrado.");
        if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            return BadRequest("Senha inválida.");

        var token = GenerateJwt(user);

        return Ok(new { token, user.Role });
    }

    private string GenerateJwt(User user)
    {
        var key = Encoding.ASCII.GetBytes(_config["JWT:Secret"]);
        var tokenHandler = new JwtSecurityTokenHandler();

        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim("role", user.Role),
                new Claim("canRead", user.CanRead.ToString()),
                new Claim("canCreate", user.CanCreate.ToString()),
                new Claim("canUpdate", user.CanUpdate.ToString()),
                new Claim("canDelete", user.CanDelete.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(6),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };

        var token = tokenHandler.CreateToken(descriptor);
        return tokenHandler.WriteToken(token);
    }
}
