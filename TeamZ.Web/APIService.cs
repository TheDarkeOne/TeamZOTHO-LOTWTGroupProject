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
        private readonly SessionService session = new SessionService();
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

        public async Task<Tuple<bool, string>> PostLoginAsync(string user, string pass)
        {
            var credentials = new
            {
                Username = user,
                Password = pass,
                LoginTime = DateTime.Now,
                SessionKey = session.GenerateSessionKey(),
            };
            var result = await client.PostAsJsonAsync("api/user/loginasuser", credentials);
            return Tuple.Create(result.IsSuccessStatusCode, credentials.SessionKey);
        }

        public async Task PostLogOut(string user, string key)
        {
            var credentials = new
            {
                Username = user,
                SessionKey = key,
            };
            await client.PostAsJsonAsync("api/user/logoutuser", credentials);
        }

        public async Task<bool> PostCreateUserAsync(string user, string pass)
        {
            var newUser = new
            {
                Username = user,
                Password = pass
            };
            var result = await client.PostAsJsonAsync("api/user/createuser", newUser);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> PostCreateItemAsync(string name, decimal price, string description)
        {
            var newItem = new 
            {
                ItemName = name,
                Price = price,
                Description = description
            };
            var result = await client.PostAsJsonAsync("api/storeitem/additem", newItem);
            return result.IsSuccessStatusCode;
        }
    }
}
