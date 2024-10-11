using E_CommerceWebsiteProject.src.Models;

namespace ECommerceProject.src.Models
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public Guid UserID { get; set; }
        public User AssociatedUser { get; set; } = new User();
        public Guid StoreID { get; set; }
        public Store AssociatedStore { get; set; } = new Store();
        public string Status { get; set; } =string.Empty;
        public Payment AssociatedPayment { get; set; } = new Payment();
        public Order() : base(){}
    }
}