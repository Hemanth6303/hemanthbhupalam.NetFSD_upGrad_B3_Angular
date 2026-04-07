using ContactManagementSystem.Services;
using System.Security.Cryptography.Pkcs;
using ContactManagementSystem.Models;
using ContactManagementSystem.Repository;



namespace ContactManagementSystem.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repo;

        public ContactService(IContactRepository repo)
        {
            _repo = repo;
        }

        public List<ContactInfo> GetAllContacts() => _repo.GetAllContacts();

        public ContactInfo GetContactById(int id) => _repo.GetContactById(id);

        public void AddContact(ContactInfo contact)
        {
            if (string.IsNullOrEmpty(contact.FirstName))
                throw new Exception("First Name required");

            _repo.AddContact(contact);
        }

        public void UpdateContact(ContactInfo contact) => _repo.UpdateContact(contact);

        public void DeleteContact(int id) => _repo.DeleteContact(id);

        public List<Company> GetCompanies() => _repo.GetCompanies();

        public List<Department> GetDepartments() => _repo.GetDepartments();
    }
}
