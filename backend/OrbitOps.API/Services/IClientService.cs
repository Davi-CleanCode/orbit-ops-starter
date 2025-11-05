
using OrbitOps.API.Models;

namespace OrbitOps.API.Services;

public interface IClientService
{
    Task<IEnumerable<Client>> GetAllAsync();
    Task<Client?> GetByIdAsync(Guid id);
    Task<Client> CreateAsync(Client client);
    Task<bool> DeleteAsync(Guid id);
}
