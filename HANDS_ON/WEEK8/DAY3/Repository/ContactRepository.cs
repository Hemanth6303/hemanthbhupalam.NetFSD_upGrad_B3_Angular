using WebApplication37.Models;

namespace WebApplication37.Repository
{
    public class ContactRepository : IContactRepository
    {
        public static List<ContactInfo> contacts = new List<ContactInfo>();
        private static int nextId = 1;

        public async Task<IEnumerable<ContactInfo>> GetAllAsync()
        {
            return await Task.FromResult(contacts);
        }

        public async Task<ContactInfo> GetByIdAsync(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            return await Task.FromResult(contact);
        }

        public async Task<ContactInfo> AddAsync(ContactInfo contact)
        {
            contact.ContactId = nextId++;
            contacts.Add(contact);
            return await Task.FromResult(contact);
        }

        public async Task<bool> UpdateAsync(int id, ContactInfo contact)
        {
            var existing = contacts.FirstOrDefault(c => c.ContactId == id);

            if (existing == null)
                return await Task.FromResult(false);

            existing.FirstName = contact.FirstName;
            existing.LastName = contact.LastName;
            existing.EmailId = contact.EmailId;
            existing.MobileNo = contact.MobileNo;
            existing.Designation = contact.Designation;
            existing.CompanyId = contact.CompanyId;
            existing.DepartmentId = contact.DepartmentId;

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);

            if (contact == null)
                return await Task.FromResult(false);

            contacts.Remove(contact);
            return await Task.FromResult(true);
        }
    }
}
