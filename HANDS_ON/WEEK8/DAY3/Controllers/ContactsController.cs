using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication37.Models;
using WebApplication37.Repository;

namespace WebApplication37.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _repository;

        public ContactsController(IContactRepository repository)
        {
            _repository = repository;
        }

        // GET: api/contacts
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _repository.GetAllAsync();
            return Ok(contacts);
        }

        // GET: api/contacts/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _repository.GetByIdAsync(id);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        // POST: api/contacts
        [HttpPost]
        public async Task<IActionResult> Create(ContactInfo contact)
        {
            if (string.IsNullOrEmpty(contact.FirstName) || string.IsNullOrEmpty(contact.EmailId))
                return BadRequest("FirstName and Email are required");

            var created = await _repository.AddAsync(contact);

            return CreatedAtAction(nameof(GetById),
                new { id = created.ContactId }, created);
        }

        // PUT: api/contacts/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ContactInfo contact)
        {
            var updated = await _repository.UpdateAsync(id, contact);

            if (!updated)
                return NotFound();

            return Ok("Updated Successfully");
        }

        // DELETE: api/contacts/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return Ok("Deleted Successfully");
        }
    }
}
