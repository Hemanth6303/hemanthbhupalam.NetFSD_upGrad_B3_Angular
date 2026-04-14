using ShopEZ.API.Models;

namespace ShopEZ.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);

        Task<User> CreateAsync(User user);
    }
}