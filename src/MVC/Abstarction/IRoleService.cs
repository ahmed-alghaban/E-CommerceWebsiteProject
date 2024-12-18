using E_CommerceWebsiteProject.MVC.Dtos.Roles;
using E_CommerceWebsiteProject.src.MVC.Utilities;
using ECommerceProject.src.Models;

namespace E_CommerceWebsiteProject.MVC.Abstarction
{
    public interface IRoleService
    {
        Task<PaginationResponse<Role>> GetAllRolesAsync(int pageNumber, int pageSize, string searchValue);
        Task<RoleDto> GetRoleByIdAsync(Guid id);
        Task<RoleDto> CreateRoleAsync(RoleCreateDto newRole);
        Task<RoleDto?> UpdateRoleAsync(Guid id, RoleUpdateDto updatedRole);
        Task<bool> DeleteRoleAsync(Guid id);
    }
}