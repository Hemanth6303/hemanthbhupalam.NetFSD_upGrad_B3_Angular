using System.Data;
using Microsoft.Data.SqlClient;   // ✅ IMPORTANT
using Microsoft.Extensions.Configuration;


namespace ContactManagementSystem
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            // 🔍 Debug (optional)
            Console.WriteLine("Connection String: " + connectionString);

            return new SqlConnection(connectionString);
        }
    }
}