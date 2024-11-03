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
        private readonly InventoryReadings _inventoryReadings;

        public ProductService(AppDbContext appDbContext, IMapper mapper, InventoryReadings inventoryReadings)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _inventoryReadings = inventoryReadings;

        }

        public async Task<PaginationResponse<Product>> GetAllProductsAsync(int pageNumber, int pageSize)
        {
            var products = _appDbContext.Products.Any()
            ?
            await _appDbContext.Products
            .Include(product => product.ImageList)
            .Include(product => product.AssociatedStore)
            .ToListAsync()
            :
            throw new Exception("there is no products");            
            return await PaginationSearch.PaginationAsync(products, pageNumber, pageSize);
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid id)
        {
            var foundProduct = await _appDbContext.Products
            .Include(product => product.ImageList)
            .Include(product => product.AssociatedStore)
            .FirstOrDefaultAsync(product => product.ID == id)
            ?? throw new Exception("product not found");
            return _mapper.Map<ProductDto>(foundProduct);
        }

        public async Task<ProductDto> CreateProductAsync(ProductCreateDto newProduct)
        {
            var createProduct = _mapper.Map<Product>(newProduct);
            await _appDbContext.Products.AddAsync(createProduct);
            await _appDbContext.SaveChangesAsync();
            await _inventoryReadings.UpdateInventoryReadings(createProduct.InventoryID);
            return await GetProductByIdAsync(createProduct.ID);
        }

        public async Task<ProductDto?> UpdateProductAsync(Guid id, ProductUpdateDto updatedProduct)
        {
            var foundProduct = await _appDbContext.Products.FindAsync(id)
            ?? throw new Exception("product not found");
            _mapper.Map(updatedProduct, foundProduct);
            foundProduct.UpdatedAt = DateTime.UtcNow;
            _appDbContext.Products.Update(foundProduct);
            await _appDbContext.SaveChangesAsync();
            await _inventoryReadings.UpdateInventoryReadings(foundProduct.InventoryID);
            return await GetProductByIdAsync(foundProduct.ID);
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var foundProduct = await _appDbContext.Products.FindAsync(id)
            ?? throw new Exception("product not found");
            Console.WriteLine($"{foundProduct.StoreID}");
            _appDbContext.Products.Remove(foundProduct);
            await _appDbContext.SaveChangesAsync();
            await _inventoryReadings.UpdateInventoryReadings(foundProduct.InventoryID);
            return true;
        }
    }
}