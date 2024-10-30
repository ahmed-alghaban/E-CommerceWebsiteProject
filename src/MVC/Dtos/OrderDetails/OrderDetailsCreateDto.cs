using System.ComponentModel.DataAnnotations;

namespace E_CommerceWebsiteProject.src.MVC.Dtos.OrderDetails
{
    public class OrderDetailsCreateDto
    {
        [Required]
        public Guid OrderID { get; set; }
        [Required]
        public Guid ProductID { get; set; }
        public int ProductQuantity { get; set; }
    }
}