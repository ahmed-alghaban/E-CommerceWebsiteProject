namespace ECommerceProject.src.Models
{
    public class OrderDetail
    {
        public Guid OrderID { get; set; }
        public Order AssociatedOrder { get; set; } = new Order();
        public Guid ProductID { get; set; } 
        public Product AssociatedProduct { get; set; } = new Product();
    }
}