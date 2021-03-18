using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly SaltAndHashService saltAndHashService;
        public UserController(IDataService dataService, ValidateClass validateClass, SaltAndHashService saltAndHashService)
        {
            this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            this.validateClass = validateClass ?? throw new ArgumentNullException(nameof(validateClass));
            this.saltAndHashService = saltAndHashService ?? throw new ArgumentNullException(nameof(saltAndHashService));
        }

        [HttpPost("[action]")]
        public async Task<List<string>> GetUsers() => await dataService.StoreUsers.Select(u => u.Username).ToListAsync();

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser(StoreUser user)
        {
            if (validateClass.ValidateUsername(user.Username))
            {
                (user.Password, user.Salt) = saltAndHashService.SaltAndHash(user.Password);
                await dataService.CreateStoreUser(user);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult LogInAsUser(string username, string password)
        {
            if (dataService.StoreUsers.Any(u => u.Username == username)) 
            {
                StoreUser user = dataService.StoreUsers.Where(u => u.Username == username).FirstOrDefault();
                string hashedPass;
                (hashedPass, _) = saltAndHashService.SaltAndHash(password, user.Salt);
                if (hashedPass == user.Password)
                {
                    return Ok();
                }
            }
            return BadRequest();
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
            }
            return BadRequest();
        }
    }
}
