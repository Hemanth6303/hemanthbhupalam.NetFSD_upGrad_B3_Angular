namespace ShopEZ.API.DTOs.Product
{
    public class ProductReadDTO
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public int Stock { get; set; }
    }
}