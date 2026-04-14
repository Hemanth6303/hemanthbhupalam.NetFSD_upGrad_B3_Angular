using System;
using System.Collections.Generic;

namespace ShopEZ.API.DTOs.Order
{
    public class OrderReadDTO
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public List<OrderItemDetailsDTO> Items { get; set; }
    }
}