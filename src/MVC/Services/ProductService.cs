using AutoMapper;
using E_CommerceWebsiteProject.src.MVC.Abstarction;
using E_CommerceWebsiteProject.src.MVC.Dtos.Products;
using E_CommerceWebsiteProject.src.MVC.Utilities;
using ECommerceProject.src.DB;
using ECommerceProject.src.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceWebsiteProject.src.MVC.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public ProductService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = _appDbContext.Products.Any()
            ?
            await _appDbContext.Products.ToListAsync()
            :
            throw new Exception("there is no products");
            return products;
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid id)
        {
            var foundProduct = await _appDbContext.Products.FindAsync(id)
            ?? throw new Exception("product not found");
            return _mapper.Map<ProductDto>(foundProduct);
        }

        public async Task<ProductDto> CreateProductAsync(ProductCreateDto newProduct)
        {
            var createProduct = _mapper.Map<Product>(newProduct);
            await _appDbContext.Products.AddAsync(createProduct);
            await _appDbContext.SaveChangesAsync();
            await InventoryReadings.UpdateInventoryReadings(createProduct.InventoryID);
            return _mapper.Map<ProductDto>(createProduct);
        }

        public async Task<ProductDto?> UpdateProductAsync(Guid id, ProductUpdateDto updatedProduct)
        {
            var foundProduct = await _appDbContext.Products.FindAsync(id)
            ?? throw new Exception("product not found");
            _mapper.Map(updatedProduct, foundProduct);
            foundProduct.UpdatedAt = DateTime.UtcNow;
            _appDbContext.Products.Update(foundProduct);
            await _appDbContext.SaveChangesAsync();
            await InventoryReadings.UpdateInventoryReadings(foundProduct.InventoryID);
            return _mapper.Map<ProductDto>(foundProduct);
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var foundProduct = await _appDbContext.Products.FindAsync(id)
            ?? throw new Exception("product not found");
            Console.WriteLine($"{foundProduct.StoreID}");
            _appDbContext.Products.Remove(foundProduct);
            await _appDbContext.SaveChangesAsync();
            await InventoryReadings.UpdateInventoryReadings(foundProduct.InventoryID);
            return true;
        }
    }
}