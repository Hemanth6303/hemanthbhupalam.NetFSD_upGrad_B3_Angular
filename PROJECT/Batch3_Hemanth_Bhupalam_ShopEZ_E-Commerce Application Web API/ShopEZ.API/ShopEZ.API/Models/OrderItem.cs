namespace ShopEZ.API.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        // Navigation Properties
        public Order Order { get; set; }

        public Product Product { get; set; }
    }
}