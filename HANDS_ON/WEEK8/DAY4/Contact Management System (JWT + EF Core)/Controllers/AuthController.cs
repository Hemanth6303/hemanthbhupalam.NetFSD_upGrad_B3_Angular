using Contact_Management_System__JWT___EF_Core_.Data;
using Contact_Management_System__JWT___EF_Core_.Models;
using Contact_Management_System__JWT___EF_Core_.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contact_Management_System__JWT___EF_Core_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;

        public AuthController(AppDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserModel user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("User Registered");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserModel user)
        {
            var dbUser = await _context.Users
                .FirstOrDefaultAsync(x => x.Username == user.Username && x.Password == user.Password);

            if (dbUser == null)
                return Unauthorized("Invalid Credentials");

            var token = _jwtService.GenerateToken(dbUser);

            return Ok(new
            {
                token = token,
                username = dbUser.Username,
                role = dbUser.Role
            });
        }
    }
}