using ContactManagement.API.DTOs;
using ContactManagement.API.Performance.Models;
using ContactManagement.API.Performance.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace ContactManagement.API.Performance.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repo;
        private readonly IMemoryCache _cache;

        public ContactService(IContactRepository repo, IMemoryCache cache)
        {
            _repo = repo;
            _cache = cache;
        }

        public async Task<PagedResponse<Contact>> GetAllAsync(int pageNumber, int pageSize)
        {
            string cacheKey = "contacts";

            if (!_cache.TryGetValue(cacheKey, out List<Contact> contacts))
            {
                contacts = await _repo.GetAllAsync();

                var options = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(60));

                _cache.Set(cacheKey, contacts, options);
            }
            else
            {
                Console.WriteLine("Fetching from CACHE...");
            }

            var totalRecords = contacts.Count;
            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            var data = contacts
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResponse<Contact>
            {
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                Data = data
            };
        }

        public async Task<Contact?> GetByIdAsync(int id)
        {
            string cacheKey = $"contact_{id}";

            if (!_cache.TryGetValue(cacheKey, out Contact contact))
            {
                contact = await _repo.GetByIdAsync(id);

                if (contact != null)
                {
                    _cache.Set(cacheKey, contact,
                        new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(60)));
                }
            }
            else
            {
                Console.WriteLine("Fetching from CACHE...");
            }

            return contact;
        }
    }
}
