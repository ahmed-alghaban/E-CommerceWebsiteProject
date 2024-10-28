using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using E_CommerceWebsiteProject.MVC.Abstarction;
using E_CommerceWebsiteProject.src.MVC.Dtos.Stores;
using ECommerceProject.src.DB;
using ECommerceProject.src.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceWebsiteProject.src.MVC.Services
{
    public class StoreService : IStoreService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public StoreService(AppDbContext appDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        public async Task<List<Store>> GetAllStoresAsync()
        {
            return await _appDbContext.Stores.Include(store => store.AssociatedUser).ToListAsync();
        }

        public async Task<StoreDto> GetStoreByIdAsync(Guid id)
        {
            var foundStore = await _appDbContext.Stores.FindAsync(id)
            ?? throw new Exception("Store was not found");
            return _mapper.Map<StoreDto>(foundStore);
        }

        public async Task<StoreDto> CreateStoreAsync(StoreCreateDto newStore)
        {
            var createdStore = _mapper.Map<Store>(newStore);
            await _appDbContext.AddAsync(createdStore);
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<StoreDto>(createdStore);
        }

        public async Task<StoreDto?> UpdateStoreAsync(Guid id, StoreUpdateDto updatedStore)
        {
            var foundStore = await _appDbContext.Stores.FindAsync(id)
            ?? throw new Exception("Store was not found");
            _mapper.Map(updatedStore, foundStore);
            foundStore.UpdatedAt = DateTime.UtcNow;
            _appDbContext.Update(foundStore);
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<StoreDto>(foundStore);
        }

        public async Task<bool> DeleteStoreAsync(Guid id)
        {
            var foundStore = await _appDbContext.Stores.FindAsync(id)
            ?? throw new Exception("Store was not found");
            _appDbContext.Stores.Remove(foundStore);
            return true;
        }

    }
}