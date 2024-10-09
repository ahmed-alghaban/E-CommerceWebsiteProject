
using ECommerceProject.src.Utilities;
namespace ECommerceProject.src.Models
{
    public class Inventory : BaseClass
    {
        public string InventoryName  { get; set; } = string.Empty;
        public int NumberOfItems { get; set; }
        public int TotalQuantity { get; set; }
        public Guid StoreID { get; set; }
        public Store AssociatedStore { get; set; } = new Store();
        public Inventory():base(){}

    }
}