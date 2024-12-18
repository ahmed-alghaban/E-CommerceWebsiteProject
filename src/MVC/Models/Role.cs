using System.Text.Json.Serialization;
using ECommerceProject.src.Utilities;

namespace ECommerceProject.src.Models
{
    public class Role : BaseClass
    {
        public string RoleName { get; set; } = string.Empty;
        public string? RoleDescription { get; set; } = string.Empty;
        public List<User> UsersList { get; set; } = new List<User>();
        public Role() : base() { }
    }
}