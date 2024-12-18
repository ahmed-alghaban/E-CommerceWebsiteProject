using E_CommerceWebsiteProject.MVC.Utilities;
using E_CommerceWebsiteProject.src.MVC.Abstarction;
using E_CommerceWebsiteProject.src.MVC.Dtos.Inventories;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceWebsiteProject.src.MVC.Controllers
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
        public async Task<IActionResult> GetAllInventory([FromQuery] string searchValue = "", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
        {
            try
            {
                var inventories = await _inventoryService.GetAllInventoriesAsync(pageNumber, pageSize, searchValue);
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
                return BadRequest(ex.Message);
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
                return BadRequest(ex.Message);
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
                return BadRequest(ex.Message);
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
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteInventory(Guid id)
        {
            try
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}