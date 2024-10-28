using System.ComponentModel.DataAnnotations;

namespace E_CommerceWebsiteProject.src.MVC.Dtos.Inventories
{
    public class InventoryCreateDto
    {
        [Required(ErrorMessage = "Inventory name is required")]
        public string InventoryName { get; set; }
        public int NumberOfItems { get; set; }
        public int TotalQuantity { get; set; }

        [Required(ErrorMessage = "The Store identity is required")]
        public Guid StoreID { get; set; }
    }
}