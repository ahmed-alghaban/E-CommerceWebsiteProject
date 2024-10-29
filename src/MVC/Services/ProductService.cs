using AutoMapper;
using E_CommerceWebsiteProject.src.MVC.Abstarction;
using E_CommerceWebsiteProject.src.MVC.Dtos.Products;
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
            var foundInventory = await _appDbContext.Inventories.FindAsync(newProduct.InventoryID)
            ?? throw new Exception("Inventory not found");
            foundInventory.TotalQuantity = _appDbContext.Products
            .Where(product => product.InventoryID == foundInventory.ID)
            .Select(product => product.Quantity)
            .Sum();
            int numberOfProducts = _appDbContext.Products.Count(product => product.InventoryID == foundInventory.ID);
            foundInventory.NumberOfItems = numberOfProducts; // adding the number of products where the have the same store as the inventory
            Console.WriteLine($"{foundInventory.NumberOfItems}");
            _appDbContext.Inventories.Update(foundInventory);
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<ProductDto>(createProduct);
        }

        public async Task<ProductDto?> UpdateProductAsync(Guid id, ProductUpdateDto updatedProduct)
        {
            var foundProduct = await _appDbContext.Products.FindAsync(id)
            ?? throw new Exception("product not found");
            var foundInventory = await _appDbContext.Inventories.FindAsync(foundProduct.InventoryID)
            ?? throw new Exception("Inventory not found");
            _mapper.Map(updatedProduct, foundProduct);
            foundProduct.UpdatedAt = DateTime.UtcNow;
            _appDbContext.Products.Update(foundProduct);
            await _appDbContext.SaveChangesAsync();
            foundInventory.TotalQuantity = _appDbContext.Products
            .Where(product => product.InventoryID == foundInventory.ID)
            .Select(product => product.Quantity)
            .Sum();
            foundInventory.UpdatedAt = DateTime.UtcNow;
            _appDbContext.Inventories.Update(foundInventory);
            await _appDbContext.SaveChangesAsync();
            Console.WriteLine($"{foundInventory.TotalQuantity}");

            return _mapper.Map<ProductDto>(foundProduct);
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var foundProduct = await _appDbContext.Products.FindAsync(id)
            ?? throw new Exception("product not found");
            Console.WriteLine($"{foundProduct.StoreID}");
            var foundInventory = await _appDbContext.Inventories.FindAsync(foundProduct.InventoryID)
            ?? throw new Exception("Inventory not found");
            _appDbContext.Products.Remove(foundProduct);
            await _appDbContext.SaveChangesAsync();
            foundInventory.TotalQuantity = _appDbContext.Products
            .Where(product => product.InventoryID == foundInventory.ID)
            .Select(product => product.Quantity)
            .Sum();
            int numberOfProducts = _appDbContext.Products.Count(product => product.InventoryID == foundInventory.ID);
            foundInventory.NumberOfItems = numberOfProducts; // replacing the old list count with the new one
            _appDbContext.Inventories.Update(foundInventory);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}