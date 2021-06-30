using Newtonsoft.Json;
using OH.Common.GroceryList;
using OH.Common.GroceryList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OH.UI.GroceryList
{
    public class ShoppingListService : IShoppingListService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ShoppingListService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<User>> GetShoppingList()
        {
            string endpoint = "/api/shoppingList";

            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

            var client = _clientFactory.CreateClient("shoppingListAPI");

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return new List<User>();
            }

            var responseJsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(true);

            return JsonConvert.DeserializeObject<List<User>>(responseJsonString);
        }

        public async Task<List<ShoppingList>> GetShoppingListByUser(int userId)
        {
            string endpoint = $"/api/shoppingList?userId={userId}";

            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

            var client = _clientFactory.CreateClient("shoppingListAPI");

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return new List<ShoppingList>();
            }

            var responseJsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(true);
            //
            return JsonConvert.DeserializeObject<List<ShoppingList>>(responseJsonString);
        }
        public async Task<List<ShoppingList>> AddShoppingListItem(ShoppingList newListEntry)
        {
            string endpoint = $"/api/shoppingList";

            var payload = JsonConvert.SerializeObject(newListEntry);

            var request = new HttpRequestMessage(HttpMethod.Post, endpoint);

            request.Content = new StringContent(payload, Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient("shoppingListAPI");

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return new List<ShoppingList>();
            }

            var responseJsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(true);

            return JsonConvert.DeserializeObject<List<ShoppingList>>(responseJsonString);
        }

        public async Task<List<ShoppingList>> RemoveShoppingListItem(ShoppingList listRemovalItem)
        {
            string endpoint = "/api/shoppingList";

            var payload = JsonConvert.SerializeObject(listRemovalItem);

            var request = new HttpRequestMessage(HttpMethod.Put, endpoint);

            request.Content = new StringContent(payload, Encoding.UTF8, "application/json");
           

            var client = _clientFactory.CreateClient("shoppingListAPI");

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return new List<ShoppingList>();
            }

            var responseJsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(true);

            return JsonConvert.DeserializeObject<List<ShoppingList>>(responseJsonString);
        }

        public async Task<List<User>> GetShoppingUserList()
        {
            string endpoint = "/api/shoppingList";

            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

            var client = _clientFactory.CreateClient("shoppingListAPI");

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return new List<User>();
            }

            var responseJsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(true);

            return JsonConvert.DeserializeObject<List<User>>(responseJsonString);
        }
    }
}
