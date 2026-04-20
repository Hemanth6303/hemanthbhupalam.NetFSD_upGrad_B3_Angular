using CategoryService.Models;

namespace CategoryService.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<Category> Add(Category category);
        Task Update(Category category);
        Task Delete(int id);
    }
}