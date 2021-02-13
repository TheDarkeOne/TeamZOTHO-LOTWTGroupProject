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
        private readonly ValidateClass validateClass;
        public StoreItemController(IDataService dataService, ValidateClass validateClass)
        {
            this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            this.validateClass = validateClass ?? throw new ArgumentNullException(nameof(validateClass));
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddCategory(Category category)
        {
            if (validateClass.ValidateCategory(category))
            {
                await dataService.CreateCategory(category);
                return Ok();
            } else
            {
                return BadRequest();
            }
        }
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddItem(StoreItem item)
        {
            if (validateClass.ValidateStoreItem(item))
            {
                await dataService.CreateItem(item);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConstructACroc(string color, string hobby, string hat="", string tail="", string heldItem="")
        {
            StoreItem item = new StoreItem($"{hobby} Croc", (decimal)49.99);
            item.Description = new DescriptionBuilderService(color, hobby).WithFancyTail(tail).WithHat(hat).WithHeldItem(heldItem).Build();
            if (validateClass.ValidateStoreItem(item))
            {
                await dataService.CreateItem(item);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateItem(StoreItem item)
        {
            if (validateClass.ValidateStoreItem(item))
            {
                await dataService.UpdateItem(item);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            if (validateClass.ValidateCategory(category))
            {
                await dataService.UpdateCategory(category);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
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
