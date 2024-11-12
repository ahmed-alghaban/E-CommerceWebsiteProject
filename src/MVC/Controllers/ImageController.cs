using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_CommerceWebsiteProject.MVC.Utilities;
using E_CommerceWebsiteProject.src.MVC.Abstarction;
using E_CommerceWebsiteProject.src.MVC.Dtos.Images;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceWebsiteProject.src.MVC.Controllers
{
    [ApiController]
    [Route("api/images")]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetImages()
        {
            try
            {
                var images = await _imageService.GetAllImagesAsync();
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "operation done successfully",
                    Data = new
                    {
                        userData = images
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
        public async Task<IActionResult> GetImagesById(Guid id)
        {
            try
            {
                var image = await _imageService.GetImageByIdAsync(id);
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "operation done successfully",
                    Data = new
                    {
                        userData = image
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
        public async Task<IActionResult> CreateImage(ImageCreateDto newImage)
        {
            try
            {
                var image = await _imageService.CreateImageAsync(newImage);
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "Image Created successfully",
                    Data = image
                };
                return Created("", response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateImage(Guid id, ImageUpdateDto updatedImage)
        {
            try
            {
                var image = await _imageService.UpdateImageAsync(id, updatedImage);
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "Image Updated Successfully",
                    Data = image
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteImage(Guid id)
        {
            try
            {
                var isDeleted = await _imageService.DeleteImageAsync(id);
                var response = new ApiResponse<object>
                {
                    IsSuccess = isDeleted,
                    Message = isDeleted ? "Image Deleted Successfully" : "Failed to Delete Image",
                    Data = new
                    {
                        Deleted = isDeleted
                    }
                };
                return StatusCode(isDeleted ? 204 : 400, response);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }
    }
}