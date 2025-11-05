
using Microsoft.EntityFrameworkCore;
using OrbitOps.API.Data;
using OrbitOps.API.Models;

namespace OrbitOps.API.Services;

public class ClientService : IClientService
{
    private readonly AppDbContext _db;
    public ClientService(AppDbContext db) { _db = db; }

    public async Task<IEnumerable<Client>> GetAllAsync() => await _db.Clients.ToListAsync();
    public async Task<Client?> GetByIdAsync(Guid id) => await _db.Clients.FindAsync(id);
    public async Task<Client> CreateAsync(Client client) { _db.Clients.Add(client); await _db.SaveChangesAsync(); return client; }
    public async Task<bool> DeleteAsync(Guid id)
    {
        var c = await _db.Clients.FindAsync(id);
        if (c == null) return false;
        _db.Clients.Remove(c);
        await _db.SaveChangesAsync();
        return true;
    }
}
