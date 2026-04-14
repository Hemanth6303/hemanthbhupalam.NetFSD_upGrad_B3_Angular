namespace ShopEZ.API.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        // Navigation Properties
        public User User { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}