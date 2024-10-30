using E_CommerceWebsiteProject.MVC.Abstarction;
using E_CommerceWebsiteProject.MVC.Dtos.Roles;
using E_CommerceWebsiteProject.MVC.Utilities;
using ECommerceProject.src.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceWebsiteProject.MVC.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var roles = await _roleService.GetAllRolesAsync();
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "operation done successfully",
                    Data = new
                    {
                        userData = roles
                    }
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Data = null
                };
                return BadRequest(response);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetRoleById(Guid id)
        {
            try
            {
                var role = await _roleService.GetRoleByIdAsync(id);
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "operation done successfully",
                    Data = new
                    {
                        userData = role
                    }
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Data = null
                };
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleCreateDto newRole)
        {
            try
            {
                var role = await _roleService.CreateRoleAsync(newRole);
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "Role Created successfully",
                    Data = role
                };
                return Created("", response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Data = null
                };
                return BadRequest(response);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateRole(Guid id, RoleUpdateDto updatedRole)
        {
            try
            {
                var role = await _roleService.UpdateRoleAsync(id, updatedRole);
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "Role Updated Successfully",
                    Data = role
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Data = null
                };
                return BadRequest(response);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            var isDeleted = await _roleService.DeleteRoleAsync(id);
            var response = new ApiResponse<object>
            {
                IsSuccess = isDeleted,
                Message = isDeleted ? "Role Deleted Successfully" : "Failed to Delete Role",
                Data = new
                {
                    Deleted = isDeleted
                }
            };
            return StatusCode(isDeleted ? 204 : 400, response);
        }
    }
}