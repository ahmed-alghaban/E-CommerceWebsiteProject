using E_CommerceWebsiteProject.src.Models;
using ECommerceProject.src.Utilities;

namespace ECommerceProject.src.Models
{
    public class Order :BaseClass
    {
        public int OrderNumber { get; set; }
        public Guid UserID { get; set; }
        public User AssociatedUser { get; set; } = new User();
        public Guid StoreID { get; set; }
        public Store AssociatedStore { get; set; } = new Store();
        public string Status { get; set; } =string.Empty;
        public Payment AssociatedPayment { get; set; } = new Payment();
        public decimal TotalAmount { get; set; }
        public ICollection<OrderDetail> OrderDetailsList{ get; set; }=new List<OrderDetail>();
        public Order() : base(){}
    }
}