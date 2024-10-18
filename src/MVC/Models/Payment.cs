using ECommerceProject.src.Models;
using ECommerceProject.src.Utilities;

namespace E_CommerceWebsiteProject.src.Models
{
    public class Payment : BaseClass
    {
        public string TransactionID { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty ;
        public string Status { get; set; } = string.Empty;
        public Guid? OrderID { get; set; }
        public Order? AssociatedOrder { get; set; }
        public Payment() : base(){}
    }
}