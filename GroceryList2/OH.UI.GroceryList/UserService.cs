using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OH.Common.GroceryList;
using OH.Common.GroceryList.Models;

namespace OH.UI.GroceryList
{
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _clientFactory;

        public UserService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<User> AddUser(User user)
        {
            string endpoint = "/api/user";

            var payload = JsonConvert.SerializeObject(user);

            var request = new HttpRequestMessage(HttpMethod.Post, endpoint);

            request.Content = new StringContent(payload, Encoding.UTF8, "application/json");            
            
            var client = _clientFactory.CreateClient("userServiceAPI");

            var response = await client.SendAsync(request);
            
            if (!response.IsSuccessStatusCode)
            {
                return new User();
            }
            var responseJsonStr = await response.Content.ReadAsStringAsync().ConfigureAwait(true);
            return JsonConvert.DeserializeObject<User>(responseJsonStr);
        }

        public async Task<User> GetUserById(int userId)
        {
            string endpoint = $"/api/user?userId={userId}";

            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

            var client = _clientFactory.CreateClient("userServiceAPI");

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return new User();
            }
            var responseJsonStr = await response.Content.ReadAsStringAsync().ConfigureAwait(true);
            return JsonConvert.DeserializeObject<User>(responseJsonStr);
        }

        public async Task<bool> DeleteUser(int userId)
        {
            string endpoint = $"/api/user?userId={userId}";
            
            var request = new HttpRequestMessage(HttpMethod.Put, endpoint);

            var client = _clientFactory.CreateClient("userServiceAPI");

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            var responseJsonStr = await response.Content.ReadAsStringAsync().ConfigureAwait(true);
            return JsonConvert.DeserializeObject<bool>(responseJsonStr);

        }

        public async Task<bool> EditUser(int userId)
        {
            string endpoint = $"/api/user?userId={userId}";

            var request = new HttpRequestMessage(HttpMethod.Patch, endpoint);

            var client = _clientFactory.CreateClient("userServiceAPI");

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            var responseJsonStr = await response.Content.ReadAsStringAsync().ConfigureAwait(true);
            return JsonConvert.DeserializeObject<bool>(responseJsonStr);

        }
    }
}
