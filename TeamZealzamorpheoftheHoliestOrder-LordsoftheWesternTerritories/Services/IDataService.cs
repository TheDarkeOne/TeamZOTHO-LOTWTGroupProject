using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamZ.Shared;

namespace TeamZealzamorpheoftheHoliestOrder_LordsoftheWesternTerritories.Services
{
    public interface IDataService
    {
        Task<string> CreateItem(StoreItem item);
        Task<string> CreateCategory(Category category);
        Task<string> CreateTransaction(StoreTransaction transaction);
        IQueryable<StoreItem> Items { get; }
        IQueryable<Category> Categories { get; }
        IQueryable<LogMessage> LogMessages { get; }
        Task<string> UpdateItem(StoreItem item);
        Task<string> UpdateCategory(Category category);
        Task<string> DeleteItem(StoreItem item);
        Task<string> DeleteCategory(Category category);
    }
}
