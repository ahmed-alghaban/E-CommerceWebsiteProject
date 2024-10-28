using E_CommerceWebsiteProject.MVC.Utilities;
using E_CommerceWebsiteProject.src.MVC.Abstarction;
using E_CommerceWebsiteProject.src.MVC.Dtos.Products;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceWebsiteProject.src.MVC.Contollers
{
    [ApiController]
    [Route("/api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAllProductsAsync();
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "operation done successfully",
                    Data = new
                    {
                        userData = products
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
        public async Task<IActionResult> GetProductById(Guid id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "operation done successfully",
                    Data = new
                    {
                        userData = product
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
        public async Task<IActionResult> CreateInventory([FromBody] ProductCreateDto newProduct)
        {
            try
            {
                var inventory = await _productService.CreateProductAsync(newProduct);
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "Product Created successfully",
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
        public async Task<IActionResult> UpdateProduct(Guid id, ProductUpdateDto updatedProduct)
        {
            try
            {
                var product = await _productService.UpdateProductAsync(id, updatedProduct);
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "Inventory Updated Successfully",
                    Data = product
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
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var isDeleted = await _productService.DeleteProductAsync(id);
            var response = new ApiResponse<object>
            {
                IsSuccess = isDeleted,
                Message = isDeleted ? "Product Deleted Successfully" : "Product to Delete Inventory",
                Data = new
                {
                    Deleted = isDeleted
                }
            };
            return StatusCode(isDeleted ? 204 : 400, response);
        }
    }
}