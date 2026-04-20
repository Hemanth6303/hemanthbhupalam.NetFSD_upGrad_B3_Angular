using CategoryService.Models;

namespace CategoryService.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<Category> Add(Category category);
        Task Update(Category category);
        Task Delete(int id);
    }
}
