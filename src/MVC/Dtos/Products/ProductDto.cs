using System.Text.Json.Serialization;
using E_CommerceWebsiteProject.src.Models;
using ECommerceProject.src.Models;

namespace E_CommerceWebsiteProject.src.MVC.Dtos.Products
{
    public class ProductDto
    {
        public Guid ID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? ProductDescription { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryID { get; set; }
        public Guid StoreID { get; set; }
        public Guid InventoryID {get; set; }
        public Category AssociatedCategory { get; set; }
        [JsonIgnore]
        public List<Image> ImageList { get; set; }
        [JsonIgnore]
        public List<OrderDetail> OrderDetailsList { get; set; }

    }
}