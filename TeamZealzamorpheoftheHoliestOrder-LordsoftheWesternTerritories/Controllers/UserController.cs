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
        public async Task<IActionResult> CreateUser(AddObjectAttributes newUser)
        {
            if (dataService.StoreUsers.Any(u => u.Username == newUser.Username))
            {
                StoreUser user = dataService.StoreUsers.Where(u => u.Username == newUser.Username).FirstOrDefault();
                if (newUser.SessionKey == user.SessionKey)
                {
                    if (!user.Admin)
                    {
                        newUser.IsAdmin = false;
                    }
                    StoreUser storeUser = new StoreUser(newUser.IsAdmin, newUser.Name);
                    if (validateClass.ValidateUsername(storeUser.Username))
                    {
                        (storeUser.Password, storeUser.Salt) = loginService.SaltAndHash(newUser.Password);
                        await dataService.CreateStoreUser(storeUser);
                        return Ok();
                    }
                }
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
                    user.SessionKey = login.SessionKey;
                    await dataService.UpdateStoreUser(user);
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LogOutUser(LoginAttributes logout)
        {
            if (dataService.StoreUsers.Any(u => u.Username == logout.Username))
            {
                StoreUser user = dataService.StoreUsers.Where(u => u.Username == logout.Username).FirstOrDefault();
                if (logout.SessionKey == user.SessionKey)
                {
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CheckAdminStatus(LoginAttributes status)
        {
            if (dataService.StoreUsers.Any(u => u.Username == status.Username))
            {
                StoreUser user = dataService.StoreUsers.Where(u => u.Username == status.Username).FirstOrDefault();
                if (user.Admin)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateTransaction(int itemId, int quantity)
        {
            var logged = await TryLogMessage("IDataService", "Info", "Transaction: " + itemId.ToString(), "CreateTransaction");
            if (logged)
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
            }
            return BadRequest();
        }

        private async Task<bool> TryLogMessage(string service, string level, string parameters, string action)
        {
            return await dataService.LogMessage(new LogMessage { Service = service, Action = action, Parameters = parameters, Level = level, TimeStamp = DateTime.Now });
        }
    }
}
