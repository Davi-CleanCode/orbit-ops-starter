
using System.ComponentModel.DataAnnotations;

namespace OrbitOps.API.Models;

public class User
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; } = "Dev";
}
