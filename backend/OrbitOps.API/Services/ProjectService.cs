
using Microsoft.EntityFrameworkCore;
using OrbitOps.API.Data;
using OrbitOps.API.Models;

namespace OrbitOps.API.Services;

public class ProjectService : IProjectService
{
    private readonly AppDbContext _db;
    public ProjectService(AppDbContext db) { _db = db; }

    public async Task<IEnumerable<Project>> GetAllAsync() => await _db.Projects.Include(p => p.Client).ToListAsync();
    public async Task<Project?> GetByIdAsync(Guid id) => await _db.Projects.Include(p => p.Client).FirstOrDefaultAsync(p => p.Id == id);
    public async Task<Project> CreateAsync(Project project) { _db.Projects.Add(project); await _db.SaveChangesAsync(); return project; }
    public async Task<bool> DeleteAsync(Guid id)
    {
        var p = await _db.Projects.FindAsync(id);
        if (p == null) return false;
        _db.Projects.Remove(p);
        await _db.SaveChangesAsync();
        return true;
    }
}
