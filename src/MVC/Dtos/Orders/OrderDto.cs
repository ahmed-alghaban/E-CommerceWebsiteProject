using System.Text.Json.Serialization;
using E_CommerceWebsiteProject.src.Models;
using ECommerceProject.src.Models;

namespace E_CommerceWebsiteProject.src.MVC.Dtos.Orders
{
    public class OrderDto
    {
        public int OrderNumber { get; set; }
        public Guid UserID { get; set; }
        public User AssociatedUser { get; set; }
        public Guid StoreID { get; set; }
        public Store AssociatedStore { get; set; }
        public string Status { get; set; }
        public Payment AssociatedPayment { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<OrderDetail> OrderDetailsList { get; set; }
    }
}