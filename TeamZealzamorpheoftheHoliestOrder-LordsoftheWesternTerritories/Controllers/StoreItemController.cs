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
        public async Task<List<LogMessage>> GetLogMessages() => await dataService.LogMessages.ToListAsync();

        [HttpGet("[action]")]
        public async Task<StoreItem> GetItemById(int id) 
        {
            return await dataService.Items.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        [HttpGet("[action]")]
        public async Task<Category> GetCategoryById(int id)
        {
            var logged = await TryLogMessage("IDataService", "Info", id.ToString(), "GetCategoryById");
            if (logged)
            {
                return await dataService.Categories.Where(i => i.Id == id).FirstOrDefaultAsync();
            }
            else
            {
                return null;
            }
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddCategory(Category category)
        {
            var logged = await TryLogMessage("IDataService", "Info", category.Title, "AddCategory");
            if (logged)
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
            else
            {
                return BadRequest();
            }
        }


        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddItem(AddObjectAttributes newItem)
        {
            var logged = await TryLogMessage("IDataService", "Info", validateClass.ToSanitizedString(newItem.Name), "AddItem");
            if (logged)
            {
                if (dataService.StoreUsers.Any(u => u.Username == newItem.Username))
                {
                    StoreUser user = dataService.StoreUsers.Where(u => u.Username == newItem.Username).FirstOrDefault();
                    if (newItem.SessionKey == user.SessionKey)
                    {
                        if (user.Admin)
                        {
                            StoreItem item = new StoreItem(newItem.Name, newItem.Price, newItem.Description);
                            if (validateClass.ValidateStoreItem(item))
                            {
                                await dataService.CreateItem(item);
                                return Ok();
                            }
                        }
                    }
                }
            }
            return BadRequest();
        }


        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConstructACroc(CrocAttributes crocAttributes)
        {
            StoreItem item = new StoreItem($"{crocAttributes.Hobby} Croc", (decimal)49.99);
            item.Description = new DescriptionBuilderService(crocAttributes.Color, crocAttributes.Hobby)
                .WithFancyTail(crocAttributes.Tail)
                .WithHat(crocAttributes.Hat)
                .WithHeldItem(crocAttributes.HeldItem)
                .Build();
            var logged = await TryLogMessage("IDataService", "Info", item.ItemName, "ConstructACroc");
            if (logged)
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
            var logged = await TryLogMessage("IDataService", "Info", category.Title, "UpdateCategory");
            if (logged)
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
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("[action]")]
        public async Task DeleteItem(StoreItem item)
        {
            var logged = await TryLogMessage("IDataService", "Info", item.ItemName, "DeleteItem");
            if (logged)
            {
                await dataService.DeleteItem(item);
            }
        }

        [HttpPost("[action]")]
        public async Task DeleteCategory(Category category)
        {
            var logged = await TryLogMessage("IDataService", "Info", category.Title, "DeleteCategory");
            if (logged)
            {
                await dataService.DeleteCategory(category);
            }
        }
        private async Task<bool> TryLogMessage(string service, string level, string parameters, string action)
        {
            return await dataService.LogMessage(new LogMessage { Service = service, Action = action, Parameters = parameters, Level = level, TimeStamp = DateTime.Now });
        }
    }
}
