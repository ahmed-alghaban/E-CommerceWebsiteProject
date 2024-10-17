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
        public Category AssociatedCategory { get; set; } = new Category();
        public Guid InventoryID { get; set;}
        public Inventory AssociatedInventory { get; set; } = new Inventory();
        public Guid StoreID { get; set; }
        public Store AssociatedStore { get; set; } = new Store();
        [JsonIgnore]
        public List<Image> ImageList = new List<Image>();
        [JsonIgnore]
        public ICollection<OrderDetail> OrderDetailsList{ get; set; }=new List<OrderDetail>();
        public Product() : base() { }
    }
}