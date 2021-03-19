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
        private readonly LoginService loginService;
        public UserController(IDataService dataService, ValidateClass validateClass, LoginService loginService)
        {
            this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            this.validateClass = validateClass ?? throw new ArgumentNullException(nameof(validateClass));
            this.loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
        }

        [HttpPost("[action]")]
        public async Task<List<string>> GetUsers() => await dataService.StoreUsers.Select(u => u.Username).ToListAsync();

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser(StoreUser user)
        {
            if (validateClass.ValidateUsername(user.Username))
            {
                (user.Password, user.Salt) = loginService.SaltAndHash(user.Password);
                await dataService.CreateStoreUser(user);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LogInAsUser(LoginAttributes login)
        {
            if (dataService.StoreUsers.Any(u => u.Username == login.Username)) 
            {
                StoreUser user = dataService.StoreUsers.Where(u => u.Username == login.Username).FirstOrDefault();
                string hashedPass;
                (hashedPass, _) = loginService.SaltAndHash(login.Password, user.Salt);
                if (hashedPass == user.Password)
                {
                    user.LastLoginTime = login.LoginTime;
                    string key = loginService.GenerateSessionKey();
                    while (dataService.StoreUsers.Any(u => u.SessionKey == key))
                    {
                        key = loginService.GenerateSessionKey();
                    }
                    user.SessionKey = key;
                    await dataService.UpdateStoreUser(user);
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
