using Contact_Management_System__JWT___EF_Core_.Models;

namespace Contact_Management_System__JWT___EF_Core_.Repositories.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<ContactInfo>> GetAll();
        Task<ContactInfo> GetById(int id);
        Task Add(ContactInfo contact);
        Task Update(ContactInfo contact);
        Task Delete(int id);
    }
}
