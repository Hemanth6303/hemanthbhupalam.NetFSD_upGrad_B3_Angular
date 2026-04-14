using ShopEZ.API.DTOs.Order;

namespace ShopEZ.API.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderReadDTO>> GetAllAsync();

        Task<OrderReadDTO> GetByIdAsync(int id);

        Task<OrderReadDTO> CreateAsync(int userId, OrderCreateDTO dto);
    }
}