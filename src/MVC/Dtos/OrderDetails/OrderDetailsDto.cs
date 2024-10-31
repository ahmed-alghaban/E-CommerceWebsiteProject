using E_CommerceWebsiteProject.src.MVC.Dtos.Orders;
using E_CommerceWebsiteProject.src.MVC.Dtos.Products;
using ECommerceProject.src.Models;

namespace E_CommerceWebsiteProject.src.MVC.Dtos.OrderDetails
{
    public class OrderDetailsDto
    {
        public Guid OrderID { get; set; }
        public OrderDto? AssociatedOrder { get; set; }
        public Guid ProductID { get; set; }
        public ProductDto? AssociatedProduct { get; set; }
        public int ProductQuantity { get; set; }
    }
}