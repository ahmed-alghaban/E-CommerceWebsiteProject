using ECommerceProject.src.Utilities;

namespace ECommerceProject.src.Models
{
    public class Store : BaseClass
    {
        public string StoreName { get; set; } = string.Empty;
        public Guid UserID { get; set; }
        public User AssociatedUser { get; set; } = new User();
        public List<Product> ProductsList { get; set; } = new List<Product>();
        public Inventory AssociatedInventory { get; set; } = new Inventory();
        public Store() : base() { }
    }
}