using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OH.Business.GroceryList;
using OH.Common.GroceryList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//REST
//Resources
    //CRUD Operations
//HTTP VERBS
    //GET, POST, PUT, DELETE, HEAD, PATCH

//ShoppingList
    //GET
    //ShoppingList/99

    //POST




namespace OH.Service.GroceryList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListService _shoppingListService;

        public ShoppingListController(IShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }
        
        [HttpGet]
        
        public IEnumerable<Dictionary<string, int>> Get(int userId = 0)
        {
            if (userId == 0)
            {
                // **ASK ABOUT CASTING HERE! Why is this needing an explicit cast? I think that it is 
                // returning a Dictionary<string, Dictionary<string, int>
                return (IEnumerable<Dictionary<string, int>>)_shoppingListService.GetShoppingList();
            }
            else
            {
                return (IEnumerable<Dictionary<string, int>>)_shoppingListService.GetShoppingListByUser(userId);
            }
            
        } 

        [HttpGet]

        public IEnumerable<User> Get1(int userId = 0)
        {
            if (userId == 0)
            {
                // **ASK ABOUT CASTING HERE! Why is this needing an explicit cast? I think that it is 
                // returning a Dictionary<string, Dictionary<string, int>
                return _shoppingListService.GetShoppingUserList();
            }
            //else
            //{
            //    return _shoppingListService.GetShoppingListByUser(userId);
            //}
            return new List<User>();
        }

        [HttpPost]
        public IEnumerable<Dictionary<string, int>> Post(int userId = 0, string item = "", int amount = 0)
        {
            if (userId != 0)
            {
                return (IEnumerable<Dictionary<string, int>>)_shoppingListService.AddShoppingListItem(userId, item, amount);
            }
            else
            {
                return (IEnumerable<Dictionary<string, int>>)_shoppingListService.GetShoppingList();
            }
        }
    }
}
