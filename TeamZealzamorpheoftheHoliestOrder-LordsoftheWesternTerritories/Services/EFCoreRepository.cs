using Microsoft.EntityFrameworkCore;
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

        public IQueryable<StoreUser> StoreUsers => context.Users;

        public async Task<string> CreateCategory(Category category)
        {
            try
            {
                context.Categories.Add(category);
                await context.SaveChangesAsync();
                return "";
            }
            catch (DbUpdateException e)
            {
                return "Something went wrong when processing your request";
            }

        }

        public async Task<string> CreateItem(StoreItem item)
        {
            try
            {
                context.StoreItems.Add(item);
                await context.SaveChangesAsync();
                return "";
            } catch (DbUpdateException e)
            {
                return "Something went wrong when processing your request";
            }
        }

        public async Task<string> CreateStoreUser(StoreUser user)
        {
            try
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
                return "";
            } catch (DbUpdateException e)
            {
                return "Something went wrong when processing your request";
            }
        }

        public async Task<string> CreateTransaction(StoreTransaction storeTransaction)
        {
            try
            {
                context.Transactions.Add(storeTransaction);
                await context.SaveChangesAsync();
                return "";
            }
            catch (DbUpdateException e)
            {
                return "Something went wrong when processing your request";
            }
        }

        public async Task<string> DeleteCategory(Category category)
        {
            try
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
                return "";
            }
            catch (DbUpdateException e)
            {
                return "Something went wrong when processing your request";
            }

        }

        public async Task<string> DeleteItem(StoreItem item)
        {
            try
             {
                context.StoreItems.Remove(item);
                await context.SaveChangesAsync();
                return "";
            }
            catch (DbUpdateException e)
            {
                return "Something went wrong when processing your request";
            }

        }

        public async Task<string> UpdateCategory(Category category)
        {
            try
            {
                context.Categories.Update(category);
                await context.SaveChangesAsync();
                return "";
            }
            catch (DbUpdateException e)
            {
                return "Something went wrong when processing your request";
            }

        }

        public async Task<string> UpdateItem(StoreItem item)
        {
            try
            {
                context.StoreItems.Update(item);
                await context.SaveChangesAsync();
                return "";
            }
            catch (DbUpdateException e)
            {
                return "Something went wrong when processing your request";
            }

        }
    }
}
