using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OH.Business.GroceryList;
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
        public IEnumerable<string> Get(int userId = 0)
        {
            if (userId == 0)
            {
                return _shoppingListService.GetShoppingList();
            }
            else
            {
                return _shoppingListService.GetShoppingListByUser(userId);
            }
            
        }
    }
}
