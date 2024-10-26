using System.Text.Json.Serialization;
using ECommerceProject.src.Utilities;

namespace ECommerceProject.src.Models
{
    public class Store : BaseClass
    {
        public string StoreName { get; set; } = string.Empty;
        public Guid UserID { get; set; }
        [JsonIgnore]
        public User AssociatedUser { get; set; }
        [JsonIgnore]
        public List<Product> ProductsList { get; set; }
        [JsonIgnore]
        public Inventory AssociatedInventory { get; set; }
        [JsonIgnore]
        public List<Order> OrdersList { get; set; }
        public Store() : base() { }
    }
}