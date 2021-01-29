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

        [HttpGet()]
        public async Task<List<StoreItem>> Get() => await dataService.Items.ToListAsync();
    }
}
