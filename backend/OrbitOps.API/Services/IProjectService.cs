
using OrbitOps.API.Models;

namespace OrbitOps.API.Services;

public interface IProjectService
{
    Task<IEnumerable<Project>> GetAllAsync();
    Task<Project?> GetByIdAsync(Guid id);
    Task<Project> CreateAsync(Project project);
    Task<bool> DeleteAsync(Guid id);
}
