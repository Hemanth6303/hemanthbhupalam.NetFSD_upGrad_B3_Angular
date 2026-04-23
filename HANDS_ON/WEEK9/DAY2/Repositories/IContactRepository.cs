using ContactManagement.API.Performance.Models;

namespace ContactManagement.API.Performance.Repositories
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllAsync();
        Task<Contact?> GetByIdAsync(int id);
    }
}
