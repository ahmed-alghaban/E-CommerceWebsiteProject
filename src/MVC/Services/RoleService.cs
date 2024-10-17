using AutoMapper;
using E_CommerceWebsiteProject.MVC.Abstarction;
using E_CommerceWebsiteProject.MVC.Dtos.Roles;
using ECommerceProject.src.DB;
using ECommerceProject.src.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceWebsiteProject.MVC.Services
{
    public class RoleService : IRoleService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public RoleService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            var roles = await _appDbContext.Roles.ToListAsync();
            return roles;
        }
        public async Task<RoleDto> GetRoleByIdAsync(Guid id)
        {
            var role = await _appDbContext.Roles.FindAsync(id)
            ?? throw new Exception("Role was not found");
            return _mapper.Map<RoleDto>(role);
        }

        public async Task<RoleDto> CreateRoleAsync(RoleCreateDto newRole)
        {
            var createdRole = _mapper.Map<Role>(newRole);
            await _appDbContext.Roles.AddAsync(createdRole);
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<RoleDto>(createdRole);
        }

        public async Task<RoleDto?> UpdateRoleAsync(Guid id, RoleUpdateDto updatedRole)
        {
            var foundRole = await _appDbContext.Roles.FindAsync(id)
            ?? throw new Exception("Role was not found");
            _mapper.Map(updatedRole, foundRole);
            foundRole.UpdatedAt = DateTime.UtcNow;
            _appDbContext.Roles.Update(foundRole);
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<RoleDto>(foundRole);
        }

        public async Task<bool> DeleteRoleAsync(Guid id)
        {
            var role = await _appDbContext.Roles.FindAsync(id)
            ?? throw new Exception("Role was not found");
            _appDbContext.Roles.Remove(role);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}