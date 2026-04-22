using ContactManagement.API.Models;
using ContactManagement.API.Exceptions;

namespace ContactManagement.API.Services
{
    public class ContactService : IContactService
    {
        private readonly List<Contact> _contacts = new();
        private readonly ILogger<ContactService> _logger;

        public ContactService(ILogger<ContactService> logger)
        {
            _logger = logger;
        }

        public List<Contact> GetAll()
        {
            return _contacts;
        }

        public Contact GetById(int id)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id);

            if (contact == null)
                throw new NotFoundException("Contact not found");

            return contact;
        }

        public Contact Create(Contact contact)
        {
            contact.Id = _contacts.Count + 1;
            _contacts.Add(contact);

            _logger.LogInformation("Contact created: {@Contact}", contact);

            return contact;
        }

        public void Update(int id, Contact updated)
        {
            var contact = GetById(id);

            contact.Name = updated.Name;
            contact.Email = updated.Email;

            _logger.LogInformation("Contact updated: {@Contact}", contact);
        }

        public void Delete(int id)
        {
            var contact = GetById(id);

            _contacts.Remove(contact);

            _logger.LogWarning("Contact deleted: {@Contact}", contact);
        }
    }
}