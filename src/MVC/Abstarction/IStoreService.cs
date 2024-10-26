using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_CommerceWebsiteProject.src.MVC.Dtos.Stores;
using ECommerceProject.src.Models;

namespace E_CommerceWebsiteProject.MVC.Abstarction
{
    public interface IStoreService
    {
        Task<List<Store>> GetAllStoresAsync();
        Task<StoreDto> GetStoreByIdAsync(Guid id);
        Task<StoreDto> CreateStoreAsync(StoreCreateDto newStore);
        Task<StoreDto?> UpdateStoreAsync(Guid id, StoreUpdateDto updatedStore);
        Task<bool> DeleteStoreAsync(Guid id);
    }
}