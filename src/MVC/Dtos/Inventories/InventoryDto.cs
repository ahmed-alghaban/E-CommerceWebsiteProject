using ECommerceProject.src.Models;

namespace E_CommerceWebsiteProject.src.MVC.Dtos.Inventories
{
    public class InventoryDto
    {
        public Guid ID { get; set; }
        public string InventoryName { get; set; }
        public int NumberOfItems { get; set; }
        public int TotalQuantity { get; set; }
        public Guid StoreID { get; set; }
        public Store AssociatedStore { get; set; }
        public List<Product> ProductsList { get; set; }
    }
}