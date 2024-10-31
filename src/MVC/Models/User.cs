using System.Text.Json.Serialization;
using ECommerceProject.src.Utilities;

namespace ECommerceProject.src.Models
{
    public class User : BaseClass
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Guid RoleID { get; set; }
        [JsonIgnore]
        public Role AssociatedRole { get; set; }
        [JsonIgnore]
        public Store? StoreOwner { get; set; }
        public List<Order> OrdersList { get; set; } = new List<Order>();
        public User() { }
        public User(Guid id, DateTime createdAt, DateTime updatedAt) : base(id, createdAt, updatedAt) { }

    }
}