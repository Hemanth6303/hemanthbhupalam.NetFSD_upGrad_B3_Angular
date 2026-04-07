using ContactManagementSystem.Models;
using Dapper;
namespace ContactManagementSystem.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DapperContext _context;

        public ContactRepository(DapperContext context)
        {
            _context = context;
        }

        public List<ContactInfo> GetAllContacts()
        {
            var query = @"SELECT c.*, comp.CompanyName, d.DepartmentName
                          FROM ContactInfo c
                          JOIN Company comp ON c.CompanyId = comp.CompanyId
                          JOIN Department d ON c.DepartmentId = d.DepartmentId";

            using var connection = _context.CreateConnection();
            return connection.Query<ContactInfo>(query).ToList();
        }

        public ContactInfo GetContactById(int id)
        {
            using var connection = _context.CreateConnection();
            return connection.QueryFirstOrDefault<ContactInfo>(
                "SELECT * FROM ContactInfo WHERE ContactId=@Id",
                new { Id = id });
        }

        public void AddContact(ContactInfo contact)
        {
            var query = @"INSERT INTO ContactInfo 
            (FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
            VALUES (@FirstName, @LastName, @EmailId, @MobileNo, @Designation, @CompanyId, @DepartmentId)";

            using var connection = _context.CreateConnection();
            connection.Execute(query, contact);
        }

        public void UpdateContact(ContactInfo contact)
        {
            var query = @"UPDATE ContactInfo SET
                        FirstName=@FirstName,
                        LastName=@LastName,
                        EmailId=@EmailId,
                        MobileNo=@MobileNo,
                        Designation=@Designation,
                        CompanyId=@CompanyId,
                        DepartmentId=@DepartmentId
                        WHERE ContactId=@ContactId";

            using var connection = _context.CreateConnection();
            connection.Execute(query, contact);
        }

        public void DeleteContact(int id)
        {
            using var connection = _context.CreateConnection();
            connection.Execute("DELETE FROM ContactInfo WHERE ContactId=@Id", new { Id = id });
        }

        public List<Company> GetCompanies()
        {
            using var connection = _context.CreateConnection();
            return connection.Query<Company>("SELECT * FROM Company").ToList();
        }

        public List<Department> GetDepartments()
        {
            using var connection = _context.CreateConnection();
            return connection.Query<Department>("SELECT * FROM Department").ToList();
        }
    }
}
