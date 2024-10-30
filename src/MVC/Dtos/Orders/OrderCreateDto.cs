using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using E_CommerceWebsiteProject.src.MVC.Dtos.OrderDetails;
using ECommerceProject.src.Models;

namespace E_CommerceWebsiteProject.src.MVC.Dtos.Orders
{
    public class OrderCreateDto
    {
        [Required(ErrorMessage = "Order number is required")]
        public int OrderNumber { get; set; }
        [Required(ErrorMessage = "User identity is required")]
        public Guid UserID { get; set; }
        [Required(ErrorMessage = "Store identity is required")]
        public Guid StoreID { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<Order> OrderDetailsList { get; set; } = new List<Order>();
    }
}