using AutoMapper;
using E_CommerceWebsiteProject.MVC.Dtos.Categories;
using E_CommerceWebsiteProject.src.MVC.Abstarction;
using ECommerceProject.src.DB;
using ECommerceProject.src.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceWebsiteProject.src.MVC.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public CategoryService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            var categories = await _appDbContext.Categories.ToListAsync();
            return categories;
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(Guid id)
        {
            var category = await _appDbContext.Categories.FindAsync(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto newCategory)
        {
            var createdCategory = _mapper.Map<Category>(newCategory);
            await _appDbContext.Categories.AddAsync(createdCategory);
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<CategoryDto>(createdCategory);
        }

        public async Task<CategoryDto?> UpdateCategoryAsync(Guid id, CategoryUpdateDto updatedCategory)
        {
            var foundCategory = await _appDbContext.Categories.FindAsync(id)
            ?? throw new Exception("Category not found");
            _mapper.Map(updatedCategory, foundCategory);
            foundCategory.UpdatedAt = DateTime.UtcNow;
            _appDbContext.Update(foundCategory);
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<CategoryDto>(foundCategory);
        }

        public async Task<bool> DeleteCategoryAsync(Guid id)
        {
            var foundCategory = await _appDbContext.Categories.FindAsync(id)
            ?? throw new Exception("Category not found");
            _appDbContext.Categories.Remove(foundCategory);
            await _appDbContext.SaveChangesAsync();
            return true;
        }


    }
}