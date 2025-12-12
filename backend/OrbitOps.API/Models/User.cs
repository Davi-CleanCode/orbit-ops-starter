using System.ComponentModel.DataAnnotations;

namespace OrbitOps.API.Models;

public class User
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public required string Role { get; set; }

    public bool CanRead { get; set; }
    public bool CanCreate { get; set; }
    public bool CanUpdate { get; set; }
    public bool CanDelete { get; set; }
}

