using ECommerceProject.src.Models;
using ECommerceProject.src.Utilities;

namespace E_CommerceWebsiteProject.src.Models
{
    public class Image : BaseClass
    {
        public string? ImageName {get; set;} = string.Empty;
        public string Url {get; set;} = string.Empty;
        public Guid ProductID {get; set;}
        public Product AssociatedProduct {get; set;} = new Product();
        public Image() : base(){}
        
    }
}