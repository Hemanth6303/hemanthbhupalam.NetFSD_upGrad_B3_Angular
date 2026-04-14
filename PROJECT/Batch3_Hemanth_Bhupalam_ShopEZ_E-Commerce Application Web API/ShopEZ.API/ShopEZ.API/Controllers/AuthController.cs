using Microsoft.AspNetCore.Mvc;
using ShopEZ.API.DTOs.Auth;
using ShopEZ.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ShopEZ.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [AllowAnonymous] 
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
        {
            var result = await _service.RegisterAsync(dto);
            return Ok(result);
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            var result = await _service.LoginAsync(dto);
            return Ok(result);
        }
    }
}