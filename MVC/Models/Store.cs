using System.Text.Json.Serialization;
using ECommerceProject.src.Utilities;

namespace ECommerceProject.src.Models
{
    public class Store : BaseClass
    {
        public string StoreName { get; set; } = string.Empty;
        public Guid UserID { get; set; }
        public User AssociatedUser { get; set; } = new User();
        [JsonIgnore]
        public List<Product> ProductsList { get; set; } = new List<Product>();
        public Inventory AssociatedInventory { get; set; } = new Inventory();
        [JsonIgnore]
        public List<Order> OrdersList { get; set; } = new List<Order>();
        public Store() : base() { }
    }
}