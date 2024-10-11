using System.Text.Json.Serialization;
using ECommerceProject.src.Models;
using ECommerceProject.src.Utilities;

namespace E_CommerceWebsiteProject.MVC.Dtos
{
    public class UserDto : BaseClass
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set;} = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Guid RoleID  { get; set; } 
        public Role AssociatedRole { get; set; } = new Role();
        public Store? StoreOwner { get; set; } = new Store();
        [JsonIgnore]
        public List<Order> OrdersList { get; set; } = new List<Order>();
        public UserDto() : base(){}
    }
}