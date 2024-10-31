using System.Text.Json.Serialization;
using E_CommerceWebsiteProject.src.Models;
using ECommerceProject.src.Utilities;

namespace ECommerceProject.src.Models
{
    public class Product : BaseClass
    {
        public string ProductName { get; set; } = string.Empty;
        public string? ProductDescription { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryID { get; set; }
        [JsonIgnore]
        public Category AssociatedCategory { get; set; }
        public Guid InventoryID { get; set; }
        [JsonIgnore]
        public Inventory AssociatedInventory { get; set; }
        public Guid StoreID { get; set; }
        public Store AssociatedStore { get; set; }
        public List<Image> ImageList { get; set; } = new List<Image>();
        [JsonIgnore]
        public List<OrderDetail> OrderDetailsList { get; set; } = new List<OrderDetail>();
        public Product() { }
        public Product(Guid id, DateTime createdAt, DateTime updatedAt) : base(id, createdAt, updatedAt) { }
    }
}