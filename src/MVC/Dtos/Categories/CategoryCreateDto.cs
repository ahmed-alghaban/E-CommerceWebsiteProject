using System.ComponentModel.DataAnnotations;

namespace E_CommerceWebsiteProject.MVC.Dtos.Categories
{
    public class CategoryCreateDto
    {
        [Required(ErrorMessage = "Category Name is required")]
        public string CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
    }
}