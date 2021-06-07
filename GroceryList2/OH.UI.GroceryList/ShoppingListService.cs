using Newtonsoft.Json;
using OH.Common.GroceryList;
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

        public async Task<Dictionary<string, int>> GetShoppingList()
        {
            string endpoint = "/api/shoppingList";

            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

            var client = _clientFactory.CreateClient("shoppingListAPI");

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return new Dictionary<string, int>();
            }

            var responseJsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(true);

            return JsonConvert.DeserializeObject<Dictionary<string, int>>(responseJsonString);
        }

        public async Task<Dictionary<string, int>> GetShoppingListByUser(int userId)
        {
            string endpoint = $"/api/shoppingList?userId={userId}";

            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

            var client = _clientFactory.CreateClient("shoppingListAPI");

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return new Dictionary<string, int>();
            }

            var responseJsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(true);
            //
            return JsonConvert.DeserializeObject<Dictionary<string, int>>(responseJsonString);
        }
        public async Task<Dictionary<string, int>> AddShoppingListItem(int userId, string item, int amount)
        {
            string endpoint = $"/api/shoppingList";

            var request = new HttpRequestMessage(HttpMethod.Post, endpoint);

            var client = _clientFactory.CreateClient("shoppingListAPI");

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return new Dictionary<string, int>();
            }

            var responseJsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(true);

            return JsonConvert.DeserializeObject<Dictionary<string, int>>(responseJsonString);
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
