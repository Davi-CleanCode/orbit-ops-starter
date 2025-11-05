
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrbitOps.API.Models;

public class Project
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Status { get; set; } = "new";
    public Guid ClientId { get; set; }
    public Client Client { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
