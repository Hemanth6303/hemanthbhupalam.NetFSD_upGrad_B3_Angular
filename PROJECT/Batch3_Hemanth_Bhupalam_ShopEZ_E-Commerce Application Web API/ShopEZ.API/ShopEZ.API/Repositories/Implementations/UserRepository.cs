using Microsoft.EntityFrameworkCore;
using ShopEZ.API.Data;
using ShopEZ.API.Models;
using ShopEZ.API.Repositories.Interfaces;

namespace ShopEZ.API.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            
            return user;
        }
    }
}