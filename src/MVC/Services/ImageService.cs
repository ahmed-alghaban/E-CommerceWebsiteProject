using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using E_CommerceWebsiteProject.src.Models;
using E_CommerceWebsiteProject.src.MVC.Abstarction;
using E_CommerceWebsiteProject.src.MVC.Dtos.Images;
using ECommerceProject.src.DB;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceWebsiteProject.src.MVC.Services
{
    public class ImageService : IImageService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public ImageService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<List<Image>> GetAllImagesAsync()
        {
            var images = _appDbContext.Images.Any()
            ?
            await _appDbContext.Images.ToListAsync()
            :
            throw new Exception("There is no images");
            return images;
        }

        public async Task<ImageDto> GetImageByIdAsync(Guid id)
        {
            var foundImage = await _appDbContext.Images.FirstOrDefaultAsync(image => image.ID == id)
            ?? throw new Exception("Image not found");
            return _mapper.Map<ImageDto>(foundImage);
        }

        public async Task<ImageDto> CreateImageAsync(ImageCreateDto newImage)
        {
            var createdImage = _mapper.Map<Image>(newImage);
            await _appDbContext.Images.AddAsync(createdImage);
            await _appDbContext.SaveChangesAsync();
            return await GetImageByIdAsync(createdImage.ID);
        }

        public async Task<ImageDto?> UpdateImageAsync(Guid id, ImageUpdateDto updatedImage)
        {
            var foundImage = await _appDbContext.Images.FindAsync(id)
            ?? throw new Exception("Image not found");
            _mapper.Map(updatedImage, foundImage);
            foundImage.UpdatedAt = DateTime.UtcNow;
            _appDbContext.Images.Update(foundImage);
            await _appDbContext.SaveChangesAsync();
            return await GetImageByIdAsync(foundImage.ID);
        }

        public async Task<bool> DeleteImageAsync(Guid id)
        {
            var foundImage = await _appDbContext.Images.FindAsync(id)
            ?? throw new Exception("Image not found");
            _appDbContext.Images.Remove(foundImage);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}