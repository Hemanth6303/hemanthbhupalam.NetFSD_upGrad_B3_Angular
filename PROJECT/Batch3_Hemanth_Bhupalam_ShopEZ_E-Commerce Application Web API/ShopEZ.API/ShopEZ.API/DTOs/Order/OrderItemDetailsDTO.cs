namespace ShopEZ.API.DTOs.Order
{
    public class OrderItemDetailsDTO
    {
        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}