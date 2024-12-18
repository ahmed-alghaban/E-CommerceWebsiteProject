using System;
using System.Net;
using E_CommerceWebsiteProject.MVC.Dtos.Categories;
using E_CommerceWebsiteProject.MVC.Utilities;
using E_CommerceWebsiteProject.src.MVC.Abstarction;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceWebsiteProject.src.MVC.Controllers
{
    [ApiController]
    [Route("/api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories([FromQuery] string searchValue = "", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
        {
            try
            {
                var categories = await _categoryService.GetAllCategoriesAsync(pageNumber, pageSize, searchValue);
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "operation done successfully",
                    Data = new
                    {
                        userData = categories
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
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(id);
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "operation done successfully",
                    Data = new
                    {
                        userData = category
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
        public async Task<IActionResult> CreateCategory(CategoryCreateDto newCategory)
        {
            try
            {
                var category = await _categoryService.CreateCategoryAsync(newCategory);
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "Category Created successfully",
                    Data = category
                };
                return Created("", response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCategory(Guid id, CategoryUpdateDto updatedCategory)
        {
            try
            {
                var category = await _categoryService.UpdateCategoryAsync(id, updatedCategory);
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "Category Updated Successfully",
                    Data = category
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            try
            {
                var isDeleted = await _categoryService.DeleteCategoryAsync(id);
                var response = new ApiResponse<object>
                {
                    IsSuccess = isDeleted,
                    Message = isDeleted ? "Category Deleted Successfully" : "Failed to Delete Category",
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