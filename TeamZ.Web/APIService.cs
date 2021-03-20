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

        public async Task PostAddItemAsync(string user, string key, string name, decimal price, string description, bool admin = false)
        {
            var item = new
            {
                Username = user,
                SessionKey = key,
                Name = name,
                Price = price,
                Description = description,
            };
            if (admin)
            {
                await client.PostAsJsonAsync("api/storeitem/additem", item);
            }
        }

        public async Task PostCreateUserAsync(string user, string key, string newUser, string newPassword, bool admin = false)
        {
            var u = new
            {
                Username = user,
                SessionKey = key,
                Name = newUser,
                Password = newPassword,
                IsAdmin = admin,
            };
            await client.PostAsJsonAsync("api/user/createuser", u);
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

        public async Task<bool> PostCheckAdminStatus(string user, string key)
        {
            var credentials = new
            {
                Username = user,
                SessionKey = key,
            };
            var result = await client.PostAsJsonAsync("api/user/checkadminstatus", credentials);
            return result.IsSuccessStatusCode;
        }
    }
}
