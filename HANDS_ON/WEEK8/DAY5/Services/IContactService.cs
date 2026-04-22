using ContactManagement.API.Models;

namespace ContactManagement.API.Services
{
    public interface IContactService
    {
        List<Contact> GetAll();
        Contact GetById(int id);
        Contact Create(Contact contact);
        void Update(int id, Contact contact);
        void Delete(int id);
    }
}