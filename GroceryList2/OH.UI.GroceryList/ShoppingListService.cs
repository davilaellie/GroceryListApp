using Newtonsoft.Json;
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

        public async Task<List<string>> GetShoppingList()
        {
            string endpoint = "/api/shoppingList";

            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

            var client = _clientFactory.CreateClient("shoppingListAPI");

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return new List<string>();
            }

            var responseJsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(true);

            return JsonConvert.DeserializeObject<List<string>>(responseJsonString);
        }

        public async Task<List<string>> GetShoppingListByUser(int userId)
        {
            string endpoint = $"/api/shoppingList?userId={userId}";

            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

            var client = _clientFactory.CreateClient("shoppingListAPI");

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return new List<string>();
            }

            var responseJsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(true);

            return JsonConvert.DeserializeObject<List<string>>(responseJsonString);
        }
    }
}
