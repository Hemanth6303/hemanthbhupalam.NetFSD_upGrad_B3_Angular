using ShopEZ.API.Models;

namespace ShopEZ.API.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(int id);

        Task<Product> CreateAsync(Product product);

        Task UpdateAsync(Product product);

        Task DeleteAsync(Product product);

        Task<IEnumerable<Product>> GetFilteredAsync(string search, decimal? minPrice, decimal? maxPrice, int pageNumber, int pageSize);

        Task<bool> ExistsAsync(int id);
    }
}