using System.ComponentModel.DataAnnotations;

namespace E_CommerceWebsiteProject.MVC.Dtos.Roles
{
    public class RoleCreateDto
    {
        [Required(ErrorMessage = "Role Name is Required")]
        public string RoleName { get; set; } = string.Empty;
        public string? RoleDescription { get; set; } = string.Empty;
    }
}