using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TeamZ.Shared;

namespace TeamZ.Web
{
    public class APIService
    {
        private readonly HttpClient client;
        public APIService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<StoreItem>> GetStoreItemsAsync()
        {
            return await client.GetFromJsonAsync<List<StoreItem>>("api/storeitem/getitems");
        }

    }
}
