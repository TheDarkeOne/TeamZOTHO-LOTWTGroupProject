using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TeamZ.Shared;
using TeamZ.Web.FormModels;

namespace TeamZ.Web
{
    public class APIService
    {
        private readonly HttpClient client;
        public APIService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<Result<List<StoreItem>>> GetStoreItemsAsync()
        {
            try
            {
                var result = await client.GetFromJsonAsync<List<StoreItem>>("api/storeitem/getitems");
                return result is null ? Result.Fail<List<StoreItem>>("No Items Found.") : Result.Ok(result);

            }
            catch (Exception e)
            {
                return Result.Fail<List<StoreItem>>("Error while getting Store Items: " + e.Message);
            }
        }

        public async Task PostConstructACrocAsync(string color, string hobby, string hat = "", string tail = "", string heldItem = "")
        {
            var croc = new
            {
                Color = color,
                Hobby = hobby,
                Hat = hat,
                Tail = tail,
                HeldItem = heldItem,
            };

            await client.PostAsJsonAsync("api/storeitem/constructacroc", croc);
        }

        public async Task<Result<StoreItem>> GetStoreItemById(int id)
        {
            try
            {
                var result = await client.GetFromJsonAsync<StoreItem>($"api/storeitem/getitembyid/?id={id}");
                return result is null ? Result.Fail<StoreItem>("No item found with this id.") : Result.Ok(result);
            } catch (Exception e)
            {
                return Result.Fail<StoreItem>("Error while getting Store Item:" + e.Message);
            }
        }

    }
}
