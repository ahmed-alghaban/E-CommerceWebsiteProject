using AutoMapper;
using E_CommerceWebsiteProject.src.MVC.Abstarction;
using E_CommerceWebsiteProject.src.MVC.Dtos.Inventories;
using E_CommerceWebsiteProject.src.MVC.Utilities;
using ECommerceProject.src.DB;
using ECommerceProject.src.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceWebsiteProject.src.MVC.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public InventoryService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<PaginationResponse<Inventory>> GetAllInventoriesAsync(int pageNumber, int pageSize)
        {
            var inventories = _appDbContext.Inventories.Any()
            ?
            await _appDbContext.Inventories
            .Include(inventory => inventory.ProductsList)
            .ToListAsync()
            :
            throw new Exception("There is no inventories");
            return await PaginationSearch.PaginationAsync(inventories, pageNumber, pageSize);
        }

        public async Task<InventoryDto> GetInventoryByIdAsync(Guid id)
        {
            var foundInventory = await _appDbContext.Inventories
            .Include(inventory => inventory.ProductsList)
            .FirstOrDefaultAsync(inventory => inventory.ID == id)
            ?? throw new Exception("Inventory not found");
            return _mapper.Map<InventoryDto>(foundInventory);
        }

        public async Task<InventoryDto> CreateInventoryAsync(InventoryCreateDto newInventory)
        {
            var createdInventory = _mapper.Map<Inventory>(newInventory);
            await _appDbContext.Inventories.AddAsync(createdInventory);
            await _appDbContext.SaveChangesAsync();
            return await GetInventoryByIdAsync(createdInventory.ID);
        }

        public async Task<InventoryDto?> UpdateInventoryAsync(Guid id, InventoryUpdateDto updatedInventory)
        {
            var foundInventory = await _appDbContext.Inventories.FindAsync(id)
            ?? throw new Exception("Inventory not found");
            _mapper.Map(updatedInventory, foundInventory);
            foundInventory.UpdatedAt = DateTime.UtcNow;
            _appDbContext.Inventories.Update(foundInventory);
            await _appDbContext.SaveChangesAsync();
            return await GetInventoryByIdAsync(foundInventory.ID);
        }

        public async Task<bool> DeleteInventoryAsync(Guid id)
        {
            var foundInventory = await _appDbContext.Inventories
            .Include(inventory => inventory.ProductsList)
            .FirstOrDefaultAsync(product => product.ID == id)
            ?? throw new Exception("Inventory not found");
            _appDbContext.Inventories.Remove(foundInventory);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}