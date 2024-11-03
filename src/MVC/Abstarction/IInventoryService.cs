using E_CommerceWebsiteProject.src.MVC.Dtos.Inventories;
using E_CommerceWebsiteProject.src.MVC.Utilities;
using ECommerceProject.src.Models;

namespace E_CommerceWebsiteProject.src.MVC.Abstarction
{
    public interface IInventoryService
    {
        Task<PaginationResponse<Inventory>> GetAllInventoriesAsync(int pageNumber, int pageSize);
        Task<InventoryDto> GetInventoryByIdAsync(Guid id);
        Task<InventoryDto> CreateInventoryAsync(InventoryCreateDto newInventory);
        Task<InventoryDto?> UpdateInventoryAsync(Guid id, InventoryUpdateDto updatedInventory);
        Task<bool> DeleteInventoryAsync(Guid id);
    }
}