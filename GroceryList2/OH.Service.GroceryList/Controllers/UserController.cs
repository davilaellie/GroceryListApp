using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OH.Business.GroceryList;
using OH.Common.GroceryList;
using OH.Common.GroceryList.Models;
using OH.Common.GroceryList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OH.Service.GroceryList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService, IShoppingListService shoppingListService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<User> Post(User user)
        {
            return await _userService.AddUser(user);
        }

        [HttpGet]
        public async Task<User> Get(int userId)
        {
            return await _userService.GetUserById(userId);
        }

        [HttpPut]
        public async Task<bool> Put(User user)
        {
            if (user.Id == 0)
            {
                return false;
            }

            return await _userService.EditUser(user);
        }

        [HttpDelete]
        public async Task<bool> Delete(int userId)
        {
            return await _userService.DeleteUser(userId);
        }

        [HttpPatch]
        public async Task<ApiResult> Patch(User user)
        {
            try
            {
                if (user == null || string.IsNullOrWhiteSpace(user.Name))
                    return new ApiResult()
                    {
                        SuccesfullCall = false,
                        ErrorMessages = new List<string>()
                        {
                            "Property name is required.",
                            "Property Last Name is missing.",
                        }
                    };

                return new ApiResult()
                {
                    SuccesfullCall = true,
                    Content = await _userService.EditUser(user)
                };

            }
            catch (InvalidOperationException ex)
            {
                //do somethig
                //recover from there
                //return valid call to the client
                return new ApiResult();
            }
            catch (Exception ex)
            {
                string uid = Guid.NewGuid().ToString();

                //log that info in the db with the uid as reference
                string errorMessage = ex.Message;

                return new ApiResult()
                {
                    SuccesfullCall = false,
                    ErrorMessages = new List<string>()
                    {
                        "There was an internal error. Contact us if the error persists",
                        $"Reference Error Number: {uid}"
                    }
                };
            }
        }
    }
}
