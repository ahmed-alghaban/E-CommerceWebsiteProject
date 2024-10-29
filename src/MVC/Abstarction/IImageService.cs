using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_CommerceWebsiteProject.src.Models;
using E_CommerceWebsiteProject.src.MVC.Dtos.Images;

namespace E_CommerceWebsiteProject.src.MVC.Abstarction
{
    public interface IImageService
    {
        Task<List<Image>> GetAllImagesAsync();
        Task<ImageDto> GetImageByIdAsync(Guid id);
        Task<ImageDto> CreateImageAsync(ImageCreateDto newImage);
        Task<ImageDto?> UpdateImageAsync(Guid id, ImageUpdateDto updatedImage);
        Task<bool> DeleteImageAsync(Guid id);
    }
}