
using System.Text.Json.Serialization;
using ECommerceProject.src.Utilities;
namespace ECommerceProject.src.Models
{
    public class Inventory : BaseClass
    {
        public string InventoryName { get; set; } = string.Empty;
        public int NumberOfItems { get; set; }
        public int TotalQuantity { get; set; }
        public Guid StoreID { get; set; }
        [JsonIgnore]
        public Store AssociatedStore { get; set; }
        [JsonIgnore]
        public List<Product> ProductsList { get; set; } = new List<Product>();
        public Inventory() { }
        public Inventory(Guid id, DateTime createdAt, DateTime updatedAt) : base(id, createdAt, updatedAt) { }
    }
}