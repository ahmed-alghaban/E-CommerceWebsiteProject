using System.Text.Json.Serialization;
using E_CommerceWebsiteProject.src.Models;
using ECommerceProject.src.Utilities;

namespace ECommerceProject.src.Models
{
    public class Order : BaseClass
    {
        public int OrderNumber { get; set; }
        public Guid UserID { get; set; }
        public User? AssociatedUser { get; set; }
        public Guid StoreID { get; set; }
        [JsonIgnore]
        public Store? AssociatedStore { get; set; }
        public string Status { get; set; } = string.Empty;
        [JsonIgnore]
        public Payment? AssociatedPayment { get; set; }
        public decimal TotalAmount { get; set; }
        [JsonIgnore]
        public ICollection<OrderDetail> OrderDetailsList { get; set; } = new List<OrderDetail>();
        public Order() { }
        public Order(Guid id, DateTime createdAt, DateTime updatedAt) : base(id, createdAt, updatedAt) { }
    }
}