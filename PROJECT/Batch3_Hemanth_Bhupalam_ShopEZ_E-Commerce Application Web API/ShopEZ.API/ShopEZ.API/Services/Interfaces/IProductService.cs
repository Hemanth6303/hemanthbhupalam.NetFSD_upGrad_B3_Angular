using ShopEZ.API.DTOs.Product;

namespace ShopEZ.API.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductReadDTO>> GetAllAsync();

        Task<ProductReadDTO> GetByIdAsync(int id);

        Task<ProductReadDTO> CreateAsync(ProductCreateDTO dto);

        Task<bool> UpdateAsync(int id, ProductUpdateDTO dto);

        Task<IEnumerable<ProductReadDTO>> GetFilteredAsync(ProductQueryDTO dto);


        Task<bool> DeleteAsync(int id);
    }
}