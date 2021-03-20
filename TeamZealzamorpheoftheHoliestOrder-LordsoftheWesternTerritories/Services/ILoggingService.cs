using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamZealzamorpheoftheHoliestOrder_LordsoftheWesternTerritories.Services
{
    public interface ILoggingService
    {
        Task<string> LogCreateItem(StoreItem item);
        Task<string> LogCreateCategory(Category category);
        Task<string> LogCreateTransaction(StoreTransaction transaction);
        IQueryable<StoreItem> LogItems { get; }
        IQueryable<Category> LogCategories { get; }
        Task<string> LogUpdateItem(StoreItem item);
        Task<string> LogUpdateCategory(Category category);
        Task<string> LogDeleteItem(StoreItem item);
        Task<string> LogDeleteCategory(Category category);
    }
}
