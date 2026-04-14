using System.ComponentModel.DataAnnotations;

namespace ShopEZ.API.DTOs.Product
{
    public class ProductCreateDTO
    {
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500)]
        public string Description { get; set; }

        [Range(1, 1000000, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Url(ErrorMessage = "Invalid Image URL")]
        public string ImageUrl { get; set; }

        [Range(0, 10000, ErrorMessage = "Stock cannot be negative")]
        public int Stock { get; set; }
    }
}