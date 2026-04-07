using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication24.Models
{
    public class Product
    {
        public int Id { get; set; } // Primary Key & Auto-Increment
        public string Name { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}