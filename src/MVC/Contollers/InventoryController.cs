using E_CommerceWebsiteProject.MVC.Utilities;
using E_CommerceWebsiteProject.src.MVC.Abstarction;
using E_CommerceWebsiteProject.src.MVC.Dtos.Inventories;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceWebsiteProject.src.MVC.Contollers
{
    [ApiController]
    [Route("api/inventories")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInventory()
        {
            try
            {
                var inventories = await _inventoryService.GetAllInventoriesAsync();
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "operation done successfully",
                    Data = new
                    {
                        userData = inventories
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
        public async Task<IActionResult> GetInventoryById(Guid id)
        {
            try
            {
                var inventory = await _inventoryService.GetInventoryByIdAsync(id);
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "operation done successfully",
                    Data = new
                    {
                        userData = inventory
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
        public async Task<IActionResult> CreateInventory([FromBody] InventoryCreateDto newInventory)
        {
            try
            {
                var inventory = await _inventoryService.CreateInventoryAsync(newInventory);
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "Inventory Created successfully",
                    Data = inventory
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
        public async Task<IActionResult> UpdateInventory(Guid id, InventoryUpdateDto updatedInventory)
        {
            try
            {
                var inventory = await _inventoryService.UpdateInventoryAsync(id, updatedInventory);
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "Inventory Updated Successfully",
                    Data = inventory
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
        public async Task<IActionResult> DeleteInventory(Guid id)
        {
            var isDeleted = await _inventoryService.DeleteInventoryAsync(id);
            var response = new ApiResponse<object>
            {
                IsSuccess = isDeleted,
                Message = isDeleted ? "Inventory Deleted Successfully" : "Failed to Delete Inventory",
                Data = new
                {
                    Deleted = isDeleted
                }
            };
            return StatusCode(isDeleted ? 204 : 400, response);
        }
    }
}