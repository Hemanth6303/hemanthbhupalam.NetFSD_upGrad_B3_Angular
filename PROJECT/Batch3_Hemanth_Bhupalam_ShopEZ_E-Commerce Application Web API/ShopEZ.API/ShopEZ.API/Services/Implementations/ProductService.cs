using ShopEZ.API.DTOs.Product;
using ShopEZ.API.Models;
using ShopEZ.API.Repositories.Interfaces;
using ShopEZ.API.Services.Interfaces;

namespace ShopEZ.API.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductReadDTO>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();

            return products.Select(p => new ProductReadDTO
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                Stock = p.Stock
            });
        }

        public async Task<ProductReadDTO> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null) 
                throw new Exception($"Product with ID {id} not found");

            return new ProductReadDTO
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Stock = product.Stock
            };
        }

        public async Task<ProductReadDTO> CreateAsync(ProductCreateDTO dto)
        {
            if (dto.Price <= 0)
                throw new Exception("Price must be greater than 0");

            if (dto.Stock < 0)
                throw new Exception("Stock cannot be negative");

            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                ImageUrl = dto.ImageUrl,
                Stock = dto.Stock
            };

            var created = await _repository.CreateAsync(product);

            return new ProductReadDTO
            {
                ProductId = created.ProductId,
                Name = created.Name,
                Description = created.Description,
                Price = created.Price,
                ImageUrl = created.ImageUrl,
                Stock = created.Stock
            };
        }

        public async Task<bool> UpdateAsync(int id, ProductUpdateDTO dto)
        {

            var product = await _repository.GetByIdAsync(id);
            if (product == null)
                throw new Exception($"Product with ID {id} not found");

            if (dto.Price <= 0)
                throw new Exception("Invalid price");

            if (dto.Stock < 0)
                throw new Exception("Invalid stock");

            if (product == null) return false;

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.ImageUrl = dto.ImageUrl;
            product.Stock = dto.Stock;

            await _repository.UpdateAsync(product);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null) return false;

            await _repository.DeleteAsync(product);

            return true;
        }
        public async Task<IEnumerable<ProductReadDTO>> GetFilteredAsync(ProductQueryDTO dto)
        {
            var products = await _repository.GetFilteredAsync(
                dto.Search,
                dto.MinPrice,
                dto.MaxPrice,
                dto.PageNumber,
                dto.PageSize
            );

            return products.Select(p => new ProductReadDTO
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                Stock = p.Stock
            });
        }
    }
}