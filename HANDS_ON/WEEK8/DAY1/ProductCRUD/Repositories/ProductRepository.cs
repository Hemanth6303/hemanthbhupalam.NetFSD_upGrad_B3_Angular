using Dapper;
using Microsoft.Data.SqlClient;
using WebApplication24.Models;

namespace WebApplication24.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connStr;
        public ProductRepository(IConfiguration config)
        {
            _connStr = config.GetConnectionString("DefaultConnection");
        }


        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connStr);
        }

        public IEnumerable<Product> GetAll()
        {
            string sqlQuery = "SELECT * FROM Products";
            var db = GetConnection();
            return db.Query<Product>(sqlQuery);

        }

        public Product GetById(int id)
        {
            string sqlQuery = "SELECT * FROM Products WHERE Id=" + id;
            var db = GetConnection();
            return db.QueryFirstOrDefault<Product>(sqlQuery);
        }

        public void Add(Product product)
        {
            string sqlQuery = @"INSERT INTO Products (Name, Price, Category) VALUES (@Name, @Price, @Category)";

            var db = GetConnection();
            db.Execute(sqlQuery, product);
        }

        public void Update(Product product)
        {
            string sqlQuery = @"UPDATE Products 
                    SET Name=@Name, Price=@Price, Category=@Category
                    WHERE Id=@Id";

            var db = GetConnection();
            db.Execute(sqlQuery, product);
        }

        public void Delete(int id)
        {
            string sqlQuery = "DELETE  FROM Products WHERE Id=" + id;

            var db = GetConnection();
            db.Execute(sqlQuery);
        }


    }
}