using ContactManagement.API.Performance.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.API.Performance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  

    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            int pageNumber = 1,
            int pageSize = 5)
        {
            var result = await _service.GetAllAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _service.GetByIdAsync(id);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }
    }
}
