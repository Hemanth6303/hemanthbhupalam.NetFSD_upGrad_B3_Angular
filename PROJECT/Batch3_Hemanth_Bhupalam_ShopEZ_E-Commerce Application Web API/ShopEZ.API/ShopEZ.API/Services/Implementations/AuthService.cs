using Microsoft.EntityFrameworkCore;
using ShopEZ.API.Data;
using ShopEZ.API.DTOs.Auth;
using ShopEZ.API.Helpers;
using ShopEZ.API.Models;
using ShopEZ.API.Repositories.Interfaces;
using ShopEZ.API.Services.Interfaces;

namespace ShopEZ.API.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly JwtTokenGenerator _jwt;
        private readonly ApplicationDbContext _context;

        public AuthService(IUserRepository userRepo, JwtTokenGenerator jwt, ApplicationDbContext context)
        {
            _userRepo = userRepo;
            _jwt = jwt;
            _context = context;
        }

        public async Task<AuthResponseDTO> RegisterAsync(RegisterDTO dto)
        {
            // Check if email already exists
            var existingUser = await _userRepo.GetByEmailAsync(dto.Email);
            if (existingUser != null)
                throw new Exception("Email already exists");

            var user = new User
            {
                
                Name = dto.Name.Trim(),
                Email = dto.Email.Trim().ToLower(),
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),

                Role = "User"
            };

            var createdUser = await _userRepo.CreateAsync(user);

            await _context.SaveChangesAsync();

            var token = _jwt.GenerateToken(createdUser);

            return new AuthResponseDTO
            {
                Email = createdUser.Email,
                Role = createdUser.Role,
                Token = token
            };
        }

        public async Task<AuthResponseDTO> LoginAsync(LoginDTO dto)
        {
            var user = await _userRepo.GetByEmailAsync(dto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid email or password");

            var token = _jwt.GenerateToken(user);
            return new AuthResponseDTO
            {
                Email = user.Email,
                Role = user.Role,
                Token = token
            };
        }
    }
}