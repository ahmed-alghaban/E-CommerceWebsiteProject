namespace ECommerceProject.src.Models
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public Guid UserID { get; set; }
        public User AssociatedUser { get; set; } = new User();
        public Guid StoreID { get; set; }
        public Store AssociatedStore { get; set; }
        public Order() : base(){}
    }
}