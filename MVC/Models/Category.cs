using System.Text.Json.Serialization;
using ECommerceProject.src.Utilities;

namespace ECommerceProject.src.Models
{
    public class Category : BaseClass
    {
        public string CaetgoryName { get; set; } = string.Empty;
        public string CaetgoryDescription { get; set; } = string.Empty;
        [JsonIgnore]
        public List<Product> ProductsList { get; set; } = new List<Product>();
        public Category():base(){}
    }
}