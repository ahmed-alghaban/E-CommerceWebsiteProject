using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ECommerceProject.src.Models;

namespace E_CommerceWebsiteProject.src.MVC.Dtos.Orders
{
    public class OrderUpdateDto
    {
        public long OrderNumber { get; set; }
        public Guid UserID { get; set; }
        public Guid StoreID { get; set; }
        public string? Status { get; set; }
        public decimal TotalAmount { get; set; }
        [JsonIgnore]
        public ICollection<OrderDetail> OrderDetailsList { get; set; }
    }
}