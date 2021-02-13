using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamZ.Shared;
using TeamZealzamorpheoftheHoliestOrder_LordsoftheWesternTerritories.Services;

namespace TeamZealzamorpheoftheHoliestOrder_LordsoftheWesternTerritories.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDataService dataService;
        private readonly ValidateClass validateClass;
        public UserController(IDataService dataService, ValidateClass validateClass)
        {
            this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            this.validateClass = validateClass ?? throw new ArgumentNullException(nameof(validateClass));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateTransaction(int itemId, int quantity)
        {
            if (validateClass.ValidateTransactionQuantity(quantity))
            {
                var item = dataService.Items.Where(i => i.Id == itemId).FirstOrDefault();
                if (item is not null)
                {
                    StoreTransaction storeTransaction = new StoreTransaction() { Quantity = quantity, Item = item };
                    await dataService.CreateTransaction(storeTransaction);
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
    }
}
