using System.Text.Json.Serialization;
using ECommerceProject.src.Utilities;

namespace ECommerceProject.src.Models
{
    public class Category : BaseClass
    {
        public string CategoryName { get; set; } = string.Empty;
        public string? CategoryDescription { get; set; } = string.Empty;
        public List<Product> ProductsList { get; set; } = new List<Product>();

        public Category() : base() { }

    }
}