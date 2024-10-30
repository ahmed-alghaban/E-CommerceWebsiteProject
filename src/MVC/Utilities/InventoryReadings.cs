using ECommerceProject.src.DB;

namespace E_CommerceWebsiteProject.src.MVC.Utilities
{
    public class InventoryReadings
    {
        private static readonly AppDbContext _appDbContext;

        public static async Task<bool> UpdateInventoryReadings(Guid id)
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