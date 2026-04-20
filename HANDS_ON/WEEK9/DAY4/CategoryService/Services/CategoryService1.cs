using CategoryService.Models;
using CategoryService.Repository;

namespace CategoryService.Services
{
    public class CategoryService1 : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService1(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Category>> GetAll() => await _repo.GetAll();
        public async Task<Category> GetById(int id) => await _repo.GetById(id);
        public async Task<Category> Add(Category category) => await _repo.Add(category);
        public async Task Update(Category category) => await _repo.Update(category);
        public async Task Delete(int id) => await _repo.Delete(id);
    }
}
