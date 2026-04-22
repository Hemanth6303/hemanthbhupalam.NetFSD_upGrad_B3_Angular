using Microsoft.AspNetCore.Mvc;
using ContactManagement.API.Services;
using ContactManagement.API.Models;

namespace ContactManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            return Ok(_service.Create(contact));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Contact contact)
        {
            _service.Update(id, contact);
            return Ok("Updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok("Deleted successfully");
        }
    }
}