using WebApplication24.Models;
using WebApplication24.Repositories;


namespace WebApplication24.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _repository.GetAll();
        }

        public Product GetProduct(int id)
        {
            return _repository.GetById(id);
        }

        public void CreateProduct(Product product)
        {
            _repository.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            _repository.Update(product);
        }

        public void DeleteProduct(int id)
        {
            _repository.Delete(id);
        }
    }
}