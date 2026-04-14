using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ShopEZ.API.DTOs.Order
{
    public class OrderCreateDTO
    {
        [Required(ErrorMessage = "Order must contain items")]
        [MinLength(1, ErrorMessage = "At least one item is required")]
        public List<OrderItemDTO> Items { get; set; } = new List<OrderItemDTO>();
    }
}