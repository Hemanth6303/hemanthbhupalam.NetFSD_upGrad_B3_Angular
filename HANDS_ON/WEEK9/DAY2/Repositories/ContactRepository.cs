using ContactManagement.API.Performance.Models;

namespace ContactManagement.API.Performance.Repositories
{

    public class ContactRepository : IContactRepository
    {
        private readonly List<Contact> _contacts;

        public ContactRepository()
        {
            _contacts = new List<Contact>
            {
                new Contact { ContactId = 1, Name = "John", Email = "john@test.com", Phone = "9999999999" },
                new Contact { ContactId = 2, Name = "Sara", Email = "sara@test.com", Phone = "8888888888" },
                new Contact { ContactId = 3, Name = "Mike", Email = "mike@test.com", Phone = "7777777777" },
                new Contact { ContactId = 4, Name = "David", Email = "david@test.com", Phone = "6666666666" },
                new Contact { ContactId = 5, Name = "Emma", Email = "emma@test.com", Phone = "5555555555" },
                new Contact { ContactId = 6, Name = "Chris", Email = "chris@test.com", Phone = "4444444444" }
            };
        }

        public Task<List<Contact>> GetAllAsync()
        {
            Console.WriteLine("Fetching from DATABASE...");
            return Task.FromResult(_contacts);
        }

        public Task<Contact?> GetByIdAsync(int id)
        {
            Console.WriteLine("Fetching from DATABASE...");
            return Task.FromResult(_contacts.FirstOrDefault(x => x.ContactId == id));
        }
    }

}
