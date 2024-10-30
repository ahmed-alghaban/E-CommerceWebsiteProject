using AutoMapper;
using E_CommerceWebsiteProject.MVC.Utilities;
using E_CommerceWebsiteProject.src.MVC.Dtos.Inventories;
using ECommerceProject.src.DB;
using ECommerceProject.src.Models;

namespace E_CommerceWebsiteProject.src.MVC.Utilities
{
    public class InventoryReadings
    {
        private readonly AppDbContext _appDbContext;

        public InventoryReadings(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> UpdateInventoryReadings(Guid id)
        {
            var foundInventory = await _appDbContext.Inventories.FindAsync(id)
            ?? throw new Exception("Inventory not found");
            foundInventory.NumberOfItems = _appDbContext.Products.Count(product => product.InventoryID == foundInventory.ID);
            foundInventory.TotalQuantity = _appDbContext.Products
            .Where(product => product.InventoryID == foundInventory.ID)
            .Select(product => product.Quantity)
            .Sum();
            foundInventory.UpdatedAt = DateTime.UtcNow;
            _appDbContext.Inventories.Update(foundInventory);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}