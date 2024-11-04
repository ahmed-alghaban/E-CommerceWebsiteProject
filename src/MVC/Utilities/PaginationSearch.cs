using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceWebsiteProject.src.MVC.Utilities
{
    public class PaginationSearch
    {
        public static async Task<PaginationResponse<T>> PaginationAsync<T>(List<T> toUseList, int pageNumber, int pageSize)
        {
            int itemsToSkip = (pageNumber - 1) * pageSize;
            return new PaginationResponse<T>
            {
                PageSize = pageSize,
                PageNumber = pageNumber,
                TotalOfPages = (int)Math.Ceiling(toUseList.Count() / (double)pageSize),
                DataObject = await Task.Run(() => toUseList.Skip(itemsToSkip).Take(pageSize).ToList())
            };
        }
    }
}