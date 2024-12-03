using System.Linq;
using AutoMapper;
using E_CommerceWebsiteProject.src.MVC.Abstarction;
using E_CommerceWebsiteProject.src.MVC.Dtos.OrderDetails;
using E_CommerceWebsiteProject.src.MVC.Dtos.Orders;
using E_CommerceWebsiteProject.src.MVC.Dtos.Products;
using E_CommerceWebsiteProject.src.MVC.Utilities;
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
        private readonly GetUserIDFromToken _getUserIDFromToken;

        public OrderService(AppDbContext appDbContext, IMapper mapper, GetUserIDFromToken getUserIDFromToken)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _getUserIDFromToken = getUserIDFromToken;
        }

        public async Task<PaginationResponse<Order>> GetAllOrdersAsync(int pageNumber, int pageSize, string searchValue)
        {
            var orders = _appDbContext.Orders.Any()
            ?
            await _appDbContext.Orders
            .Include(order => order.AssociatedUser)
            .Include(order => order.OrderDetailsList)
            .ThenInclude(orderDetail => orderDetail.AssociatedProduct)
            .ToListAsync()
            :
            throw new Exception("There is no orders");

            if (!string.IsNullOrEmpty(searchValue))
            {
                orders = await _appDbContext.Orders
                .Where(order => order.OrderNumber.ToString().Contains(searchValue))
                .Include(order => order.OrderDetailsList)
                .ThenInclude(orderDetail => orderDetail.AssociatedProduct)
                .ToListAsync();
                return await PaginationSearch.PaginationAsync(orders, pageNumber, pageSize);

            }
            return await PaginationSearch.PaginationAsync(orders, pageNumber, pageSize);
        }

        public async Task<OrderDto> GetOrderByIdAsync(Guid id)
        {
            var foundOrder = await _appDbContext.Orders
            .Include (order => order.AssociatedUser)
            .Include(order => order.AssociatedStore)
            .Include(order => order.OrderDetailsList)
            .ThenInclude(orderDetail => orderDetail.AssociatedProduct)
            .FirstOrDefaultAsync(order => order.ID == id)
            ?? throw new Exception("Order not found");
            return _mapper.Map<OrderDto>(foundOrder);
        }

        public async Task<OrderDto> CreateOrderAsync(OrderCreateDto newOrder)
        {
            var order = new Order
            {
                OrderNumber = newOrder.OrderNumber,
                UserID = _getUserIDFromToken.GetCurrentUserId(),
                StoreID = newOrder.StoreID,
                Status = newOrder.Status,
                TotalAmount = newOrder.TotalAmount,
                OrderDetailsList = new List<OrderDetail>()
            };
            foreach (var orderDetails in newOrder.OrderDetailsList)
            {
                var orderDetail = new OrderDetail
                {
                    OrderID = order.ID,
                    ProductID = orderDetails.ProductID,
                    ProductQuantity = orderDetails.ProductQuantity
                };
                order.OrderDetailsList.Add(orderDetail);
            }
            await _appDbContext.Orders.AddAsync(order);
            await _appDbContext.SaveChangesAsync();
            return await GetOrderByIdAsync(order.ID);
        }

        public async Task<bool> DeleteOrderAsync(Guid Id)
        {
            var order = await _appDbContext.Orders
            .Include(order => order.OrderDetailsList)
            .FirstOrDefaultAsync(foundOrder => foundOrder.ID == Id)
            ?? throw new Exception("Order is not found");
            _appDbContext.Orders.Remove(order);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}