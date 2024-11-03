using E_CommerceWebsiteProject.MVC.Dtos.Categories;
using E_CommerceWebsiteProject.src.MVC.Utilities;
using ECommerceProject.src.Models;

namespace E_CommerceWebsiteProject.src.MVC.Abstarction
{
    public interface ICategoryService
    {

        Task<PaginationResponse<Category>> GetAllCategoriesAsync(int pageNumber, int pageSize);
        Task<CategoryDto> GetCategoryByIdAsync(Guid id);
        Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto newCategory);
        Task<CategoryDto?> UpdateCategoryAsync(Guid id, CategoryUpdateDto updatedCategory);
        Task<bool> DeleteCategoryAsync(Guid id);
    }
}