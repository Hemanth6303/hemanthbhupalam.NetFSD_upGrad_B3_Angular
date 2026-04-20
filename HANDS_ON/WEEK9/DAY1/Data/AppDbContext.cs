
using ContactManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace ContactManagementAPI.Data
{
  

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<UserInfo> Users { get; set; }
    }
}
