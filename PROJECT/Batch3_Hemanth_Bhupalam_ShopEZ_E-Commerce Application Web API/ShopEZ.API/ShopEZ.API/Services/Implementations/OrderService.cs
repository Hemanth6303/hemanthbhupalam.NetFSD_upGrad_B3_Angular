using Microsoft.EntityFrameworkCore;
using ShopEZ.API.Data;
using ShopEZ.API.DTOs.Order;
using ShopEZ.API.Models;
using ShopEZ.API.Repositories.Implementations;
using ShopEZ.API.Repositories.Interfaces;
using ShopEZ.API.Services.Interfaces;

namespace ShopEZ.API.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IProductRepository _productRepo;
        private readonly ApplicationDbContext _context;

       

        public OrderService(IOrderRepository orderRepo, IProductRepository productRepo, ApplicationDbContext context)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _context = context;
        }

        public async Task<IEnumerable<OrderReadDTO>> GetAllAsync()
        {
            var orders = await _orderRepo.GetAllAsync();

            return orders.Select(o => new OrderReadDTO
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate,
                TotalAmount = o.TotalAmount,
                Items = o.OrderItems.Select(i => new OrderItemDetailsDTO
                {
                    ProductName = i.Product.Name,
                    Quantity = i.Quantity,
                    Price = i.Price
                }).ToList()
            });
        }

        public async Task<OrderReadDTO> GetByIdAsync(int id)
        {
            var order = await _orderRepo.GetByIdAsync(id);

            if (order == null)
                throw new Exception($"Order with ID {id} not found");

            return new OrderReadDTO
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Items = order.OrderItems.Select(i => new OrderItemDetailsDTO
                {
                    ProductName = i.Product.Name,
                    Quantity = i.Quantity,
                    Price = i.Price
                }).ToList()
            };
        }

        public async Task<OrderReadDTO> CreateAsync(int userId, OrderCreateDTO dto)
        {
            // Start transaction
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                if (dto.Items == null || !dto.Items.Any())
                    throw new Exception("Order must contain at least one item.");

                var orderItems = new List<OrderItem>();
                decimal total = 0;

                foreach (var item in dto.Items)
                {
                    var product = await _productRepo.GetByIdAsync(item.ProductId);

                    if (item.Quantity <= 0)
                        throw new Exception("Quantity must be greater than zero.");

                    if (product == null)
                        throw new Exception($"Product with ID {item.ProductId} not found.");

                    //  Stock validation
                    if (product.Stock < item.Quantity)
                        throw new Exception($"Insufficient stock for {product.Name}");

                    var orderItem = new OrderItem
                    {
                        ProductId = product.ProductId,
                        Quantity = item.Quantity,
                        Price = product.Price
                    };

                    // Calculate total
                    total += product.Price * item.Quantity;

                    // Reduce stock
                    product.Stock -= item.Quantity;
                    await _productRepo.UpdateAsync(product);

                    orderItems.Add(orderItem);
                }

                var order = new Order
                {
                    UserId = userId,
                    OrderDate = DateTime.UtcNow,
                    TotalAmount = total,
                    OrderItems = orderItems
                };

                var createdOrder = await _orderRepo.CreateAsync(order);

                //  Save all changes (IMPORTANT)
                await _context.SaveChangesAsync();

                // Commit transaction
                await transaction.CommitAsync();

                return await GetByIdAsync(createdOrder.OrderId);
            }
            catch (Exception)
            {
                //  Rollback if anything fails
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}