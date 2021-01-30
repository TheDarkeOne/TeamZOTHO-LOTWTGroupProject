using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamZ.Shared;
using TeamZealzamorpheoftheHoliestOrder_LordsoftheWesternTerritories.Services;

namespace TeamZealzamorpheoftheHoliestOrder_LordsoftheWesternTerritories.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreItemController : ControllerBase
    {

        private readonly IDataService dataService;
        public StoreItemController(IDataService dataService)
        {
            this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        [HttpGet("[action]")]
        public async Task<List<StoreItem>> GetItems() => await dataService.Items.ToListAsync();
        [HttpGet("[action]")]
        public async Task<List<Category>> GetCategories() => await dataService.Categories.ToListAsync();

        [HttpGet("[action]")]
        public async Task<StoreItem> GetItemById(int id) 
        {
            return await dataService.Items.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        [HttpGet("[action]")]
        public async Task<Category> GetCategoryById(int id)
        {
            return await dataService.Categories.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        [HttpPost("[action]")]
        public async Task AddCategory(Category category)
        {
            await dataService.CreateCategory(category);
        }
        [HttpPost("[action]")]
        public async Task AddItem(StoreItem item)
        {
            await dataService.CreateItem(item);
        }
        [HttpPost("[action]")]
        public async Task UpdateItem(StoreItem item)
        {
            await dataService.UpdateItem(item);
        }
        [HttpPost("[action]")]
        public async Task UpdateCategory(Category category)
        {
            await dataService.UpdateCategory(category);
        }
        [HttpPost("[action]")]
        public async Task DeleteItem(StoreItem item)
        {
            await dataService.DeleteItem(item);
        }

        [HttpPost("[action]")]
        public async Task DeleteCategory(Category category)
        {
            await dataService.DeleteCategory(category);
        }
    }
}
