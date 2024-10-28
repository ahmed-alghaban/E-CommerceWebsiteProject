using AutoMapper;
using E_CommerceWebsiteProject.src.MVC.Abstarction;
using E_CommerceWebsiteProject.src.MVC.Dtos.Inventories;
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

        public async Task<List<Inventory>> GetAllInventoriesAsync()
        {
            var inventories = _appDbContext.Inventories.Any()
            ?
            await _appDbContext.Inventories.ToListAsync()
            :
            throw new Exception("Inventory not found");
            return inventories;
        }

        public async Task<InventoryDto> GetInventoryByIdAsync(Guid id)
        {
            var foundInventory = await _appDbContext.Inventories.FindAsync(id)
            ?? throw new Exception("Inventory not found");
            return _mapper.Map<InventoryDto>(foundInventory);
        }

        public async Task<InventoryDto> CreateInventoryAsync(InventoryCreateDto newInventory)
        {
            var createdInventory = _mapper.Map<Inventory>(newInventory);
            await _appDbContext.Inventories.AddAsync(createdInventory);
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<InventoryDto>(createdInventory);
        }

        public async Task<InventoryDto?> UpdateInventoryAsync(Guid id, InventoryUpdateDto updatedInventory)
        {
            var foundInventory = await _appDbContext.Inventories.FindAsync(id)
            ?? throw new Exception("Inventory not found");
            _mapper.Map(updatedInventory, foundInventory);
            foundInventory.UpdatedAt = DateTime.UtcNow;
            _appDbContext.Inventories.Update(foundInventory);
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<InventoryDto>(foundInventory);
        }

        public async Task<bool> DeleteInventoryAsync(Guid id)
        {
            var foundInventory = await _appDbContext.Inventories.FindAsync(id)
            ?? throw new Exception("Inventory not found");
            _appDbContext.Inventories.Remove(foundInventory);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}