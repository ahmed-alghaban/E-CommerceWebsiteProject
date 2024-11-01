using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceWebsiteProject.src.MVC.Utilities
{
    public class PaginationSearch
    {
        public static async Task<List<T>> PaginationAsync<T>(List<T> toUseList, int pageNumber = 1, int pageSize = 20)
        {
            int itemsToSkip = (pageNumber - 1) * pageSize;
            return await Task.Run(() => toUseList.Skip(itemsToSkip).Take(pageSize).ToList());
        }

    }
}