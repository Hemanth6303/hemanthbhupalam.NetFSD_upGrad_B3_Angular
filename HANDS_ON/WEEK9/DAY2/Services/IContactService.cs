using ContactManagement.API.DTOs;
using ContactManagement.API.Performance.Models;

namespace ContactManagement.API.Performance.Services
{
    public interface IContactService
    {
        Task<PagedResponse<Contact>> GetAllAsync(int pageNumber, int pageSize);
        Task<Contact?> GetByIdAsync(int id);
    }
}
