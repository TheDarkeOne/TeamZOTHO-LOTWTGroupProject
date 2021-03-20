using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamZ.Shared;

namespace TeamZealzamorpheoftheHoliestOrder_LordsoftheWesternTerritories.Services
{
    public class LoggingEFCoreRepository : IDataService
    {
        private readonly ApplicationDBContext context;

        public LoggingEFCoreRepository(ApplicationDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<StoreItem> Items => context.StoreItems;

        public IQueryable<Category> Categories => context.Categories;

        public IQueryable<LogMessage> LogMessages => context.LogMessages;

        public IQueryable<StoreUser> StoreUsers => context.Users;

        public async Task<string> CreateCategory(Category category)
        {
            try
            {
                context.Categories.Add(category);
                context.LogMessages.Add(new LogMessage { Level = "Info", Service = "IDataService", Parameters = category.Title, TimeStamp = DateTime.Now, Action = "CreateCategory" });
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
                context.LogMessages.Add(new LogMessage { Level = "Info", Service = "IDataService", Parameters = "TransactionId: " + storeTransaction.Id, TimeStamp = DateTime.Now, Action = "CreateTransaction" });
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
                context.LogMessages.Add(new LogMessage { Level = "Info", Service = "IDataService", Parameters = category.Title, TimeStamp = DateTime.Now, Action = "DeleteCategory" });
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
                context.LogMessages.Add(new LogMessage { Level = "Info", Service = "IDataService", Parameters = item.ItemName, TimeStamp = DateTime.Now, Action = "DeleteItem" });
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
                context.LogMessages.Add(new LogMessage { Level = "Info", Service = "IDataService", Parameters = category.Title, TimeStamp = DateTime.Now, Action = "UpdateCategory" });
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
                context.LogMessages.Add(new LogMessage { Level = "Info", Service = "IDataService", Parameters = item.ItemName, TimeStamp = DateTime.Now, Action = "UpdateItem" });
                await context.SaveChangesAsync();
                return "";
            }
            catch (DbUpdateException e)
            {
                return "Something went wrong when processing your request";
            }
        }

        public async Task<string> UpdateStoreUser(StoreUser user)
        {
            try
            {
                context.Users.Update(user);
                await context.SaveChangesAsync();
                return "";
            }
            catch (DbUpdateException e)
            {
                return "Something went wrong when processing your request";
            }
        }

        public async Task<bool> LogMessage(LogMessage message)
        {
            try
            {
                context.LogMessages.Add(message);
                await context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException e)
            {
                return false;
            }
        }
    }
}
