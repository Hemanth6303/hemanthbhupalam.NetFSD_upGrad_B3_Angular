using Microsoft.EntityFrameworkCore;
using ShopEZ.API.Models;
using System.Reflection.Emit;

namespace ShopEZ.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
           new User
             {
               UserId = 1,
               Name = "Admin",
               Email = "admin@gmail.com",
               PasswordHash = "$2a$11$7.PSaQxw4V8qxxUniB2Q6u2JKVzvgoujznRMWa6Y1CEAxQG4wDa36",
               //Console.WriteLine(BCrypt.Net.BCrypt.HashPassword("Admin@123"));

               Role = "Admin"
             }
           );

            // Order → OrderItems (One-to-Many)
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            // Product → OrderItems (One-to-Many)
            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderItems)
                .WithOne(oi => oi.Product)
                .HasForeignKey(oi => oi.ProductId);

            // User → Orders (One-to-Many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);
        }
    }
}