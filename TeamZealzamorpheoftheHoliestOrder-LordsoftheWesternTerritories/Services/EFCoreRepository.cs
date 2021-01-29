using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamZ.Shared;

namespace TeamZealzamorpheoftheHoliestOrder_LordsoftheWesternTerritories.Services
{
    public class EFCoreRepository : IDataService
    {
        private readonly ApplicationDBContext context;

        public EFCoreRepository(ApplicationDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<StoreItem> Items => context.StoreItems;

        public IQueryable<Category> Categories => context.Categories;

        public async Task CreateCategory(Category category)
        {
            context.Categories.Add(category);
            await context.SaveChangesAsync();
        }

        public async Task CreateItem(StoreItem item)
        {
            context.StoreItems.Add(item);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCategory(Category category)
        {
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
        }

        public async Task DeleteItem(StoreItem item)
        {
            context.StoreItems.Remove(item);
            await context.SaveChangesAsync();
        }

        public async Task UpdateCategory(Category category)
        {
            context.Categories.Update(category);
            await context.SaveChangesAsync();
        }

        public async Task UpdateItem(StoreItem item)
        {
            context.StoreItems.Update(item);
            await context.SaveChangesAsync();
        }
    }
}
