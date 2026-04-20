using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContactManagementAPI.Data;
using ContactManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ContactManagementAPI.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetAll()
        {
            return Ok(_context.Contacts.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var contact = _context.Contacts.Find(id);
            return Ok(contact);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok(contact);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, Contact contact)
        {
            var existing = _context.Contacts.Find(id);
            if (existing == null) return NotFound();

            existing.Name = contact.Name;
            existing.Email = contact.Email;
            existing.Phone = contact.Phone;

            _context.SaveChanges();
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null) return NotFound();

            _context.Contacts.Remove(contact);
            _context.SaveChanges();

            return Ok("Deleted");
        }
    }
}
