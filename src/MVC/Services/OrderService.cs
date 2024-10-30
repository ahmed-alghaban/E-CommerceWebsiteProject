using AutoMapper;
using E_CommerceWebsiteProject.src.MVC.Abstarction;
using E_CommerceWebsiteProject.src.MVC.Dtos.OrderDetails;
using E_CommerceWebsiteProject.src.MVC.Dtos.Orders;
using E_CommerceWebsiteProject.src.MVC.Dtos.Products;
using ECommerceProject.Migrations;
using ECommerceProject.src.DB;
using ECommerceProject.src.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceWebsiteProject.src.MVC.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public OrderService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            var orders = _appDbContext.Orders.Any()
            ?
            await _appDbContext.Orders.ToListAsync()
            :
            throw new Exception("There is no orders");
            return orders;
        }

        public async Task<OrderDto> GetOrderByIdAsync(Guid id)
        {
            var foundOrder = await _appDbContext.Orders.FindAsync(id)
            ?? throw new Exception("Order not found");
            return _mapper.Map<OrderDto>(foundOrder);
        }

        public async Task<OrderDto> CreateOrderAsync(OrderCreateDto newOrder)
        {
            var order = new Order
            {
                OrderNumber = newOrder.OrderNumber,
                UserID = newOrder.UserID,
                OrderDetailsList = new List<OrderDetail>(),
                TotalAmount = newOrder.TotalAmount,
                StoreID = newOrder.StoreID,
                Status = newOrder.Status,
            };
            foreach (var orderDetails in order.OrderDetailsList)
            {
                var newOrderDetails = new OrderDetail
                {
                    OrderID = order.ID,
                    ProductID = orderDetails.ProductID,
                    ProductQuantity = orderDetails.ProductQuantity
                };
                _appDbContext.OrderDetails.Add(newOrderDetails);
                _appDbContext.SaveChanges();
            }
            await _appDbContext.Orders.AddAsync(order);
            await _appDbContext.SaveChangesAsync();
            return await GetOrderByIdAsync(order.ID);
        }
        // public async Task<OrderDto?> UpdateInventoryAsync(Guid id, OrderUpdateDto updatedOrder)
        // {

        // }
        // public async Task<bool> DeleteOrderAsync(Guid id)
        // {

        // }
    }
}