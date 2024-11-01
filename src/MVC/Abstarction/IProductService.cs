using E_CommerceWebsiteProject.src.MVC.Dtos.Products;
using ECommerceProject.src.Models;

namespace E_CommerceWebsiteProject.src.MVC.Abstarction
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync(int pageNumber, int pageSize);
        Task<ProductDto> GetProductByIdAsync(Guid id);
        Task<ProductDto> CreateProductAsync(ProductCreateDto newProduct);
        Task<ProductDto?> UpdateProductAsync(Guid id, ProductUpdateDto updatedProduct);
        Task<bool> DeleteProductAsync(Guid id);
    }
}