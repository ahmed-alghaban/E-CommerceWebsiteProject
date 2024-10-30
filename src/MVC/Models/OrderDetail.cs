using System.Text.Json.Serialization;

namespace ECommerceProject.src.Models
{
    public class OrderDetail
    {
        public Guid OrderID { get; set; }
        [JsonIgnore]
        public Order AssociatedOrder { get; set; }
        public Guid ProductID { get; set; }
        [JsonIgnore]
        public Product AssociatedProduct { get; set; }
        public int ProductQuantity { get; set; }
    }
}