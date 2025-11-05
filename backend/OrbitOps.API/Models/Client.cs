
using System.ComponentModel.DataAnnotations;

namespace OrbitOps.API.Models;

public class Client
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string? Notes { get; set; }
}
