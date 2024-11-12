using System.ComponentModel.DataAnnotations;

namespace E_CommerceWebsiteProject.src.MVC.Dtos.Products
{
    public class ProductCreateDto
    {
        [Required(ErrorMessage = "Product name is required")]
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        [Range(10, double.MaxValue, ErrorMessage = "Price must be at least 10")]
        public decimal Price { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at more than 0")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public Guid CategoryID { get; set; }
        [Required(ErrorMessage = "Store is Required")]
        public Guid StoreID { get; set; }
        [Required(ErrorMessage = "Inventory is Required")]
        public Guid InventoryID { get; set; }
    }
}