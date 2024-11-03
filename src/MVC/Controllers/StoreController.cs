using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_CommerceWebsiteProject.MVC.Abstarction;
using E_CommerceWebsiteProject.MVC.Utilities;
using E_CommerceWebsiteProject.src.MVC.Dtos.Stores;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceWebsiteProject.src.MVC.Controllers
{
    [ApiController]
    [Route("api/Stores")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStores([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
        {
            try
            {
                var stores = await _storeService.GetAllStoresAsync(pageNumber, pageSize);
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "operation done successfully",
                    Data = new
                    {
                        userData = stores
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
        public async Task<IActionResult> GetStoreById(Guid id)
        {
            try
            {
                var store = await _storeService.GetStoreByIdAsync(id);
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "operation done successfully",
                    Data = new
                    {
                        Data = store
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
        public async Task<IActionResult> CreateStore([FromBody] StoreCreateDto newStore)
        {
            try
            {
                var store = await _storeService.CreateStoreAsync(newStore);
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "Store Created successfully",
                    Data = store
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
        public async Task<IActionResult> UpdateStore(Guid id, StoreUpdateDto updatedStore)
        {
            try
            {
                var store = await _storeService.UpdateStoreAsync(id, updatedStore);
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "Store Updated Successfully",
                    Data = store
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
        public async Task<IActionResult> DeleteStore(Guid id)
        {
            var isDeleted = await _storeService.DeleteStoreAsync(id);
            var response = new ApiResponse<object>
            {
                IsSuccess = isDeleted,
                Message = isDeleted ? "Store Deleted Successfully" : "Failed to Delete Store",
                Data = new
                {
                    Deleted = isDeleted
                }
            };
            return StatusCode(isDeleted ? 204 : 400, response);
        }
    }
}