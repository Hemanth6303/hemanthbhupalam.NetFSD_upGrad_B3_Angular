using System.ComponentModel.DataAnnotations;

namespace ShopEZ.API.DTOs.Product
{
    public class ProductQueryDTO
    {
        public string? Search { get; set; }

        // Price filters
        [Range(0, double.MaxValue, ErrorMessage = "MinPrice cannot be negative")]
        public decimal? MinPrice { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "MaxPrice cannot be negative")]
        public decimal? MaxPrice { get; set; }

        // Pagination
        [Range(1, int.MaxValue, ErrorMessage = "PageNumber must be greater than 0")]
        public int PageNumber { get; set; } = 1;

        [Range(1, 100, ErrorMessage = "PageSize must be between 1 and 100")]
        public int PageSize { get; set; } = 5;
    }
}