using System.ComponentModel.DataAnnotations;

namespace E_CommerceWebsiteProject.src.MVC.Dtos.Products
{
    public class ProductsCreateDto
    {
        [Required(ErrorMessage = "Product name is required")]
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        [Range(100,double.MaxValue)]
        public decimal Price { get; set; }
        [Range(1,int.MaxValue)]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public Guid CategoryID { get; set; }
        [Required(ErrorMessage ="Store is Required")]
        public Guid StoreID { get; set; }
    }
}