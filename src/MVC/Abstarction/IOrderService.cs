using E_CommerceWebsiteProject.src.MVC.Dtos.Orders;
using E_CommerceWebsiteProject.src.MVC.Utilities;
using ECommerceProject.src.Models;

namespace E_CommerceWebsiteProject.src.MVC.Abstarction
{
    public interface IOrderService
    {
        Task<PaginationResponse<Order>> GetAllOrdersAsync(int pageNumber, int pageSize);
        Task<OrderDto> GetOrderByIdAsync(Guid id);
        Task<OrderDto> CreateOrderAsync(OrderCreateDto newOrder);
        // Task<OrderDto?> UpdateInventoryAsync(Guid id, OrderUpdateDto updatedOrder);
        Task<bool> DeleteOrderAsync(Guid id);
    }
}