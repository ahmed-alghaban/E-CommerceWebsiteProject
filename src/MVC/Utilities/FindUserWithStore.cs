using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceProject.src.DB;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceWebsiteProject.src.MVC.Utilities
{
    public class FindUserWithStore
    {
        private readonly AppDbContext _appDbContext;

        public FindUserWithStore(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Guid> FindUserWithStoreAsync(Guid id)
        {
            var foundUser = await _appDbContext.Users.FindAsync(id)
            ?? throw new Exception("User not found");
            var foundStore = await _appDbContext.Stores.FirstOrDefaultAsync(store => store.UserID == foundUser.ID)
            ?? throw new Exception("Store not found");
            foundUser.StoreOwner = foundStore;
            return foundUser.StoreOwner.ID;
        }


    }
}