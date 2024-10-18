using System.Text.Json.Serialization;
using ECommerceProject.src.Models;

namespace E_CommerceWebsiteProject.MVC.Dtos.Categories
{
    public class CategoryDto
    {
        public Guid ID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string CategoryDescription { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; }
        [JsonIgnore]
        public List<Product> ProductsList { get; set; }
    }
}