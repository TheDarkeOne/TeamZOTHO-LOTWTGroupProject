using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamZ.Shared;

namespace TeamZealzamorpheoftheHoliestOrder_LordsoftheWesternTerritories.Services
{
    public interface IDataService
    {
        Task CreateItem(StoreItem item);
        Task CreateCategory(Category category);
        IQueryable<StoreItem> Items { get; }
        IQueryable<Category> Categories { get; }
        Task UpdateItem(StoreItem item);
        Task UpdateCategory(Category category);
        Task DeleteItem(StoreItem item);
        Task DeleteCategory(Category category);
    }
}
