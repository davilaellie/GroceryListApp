using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OH.Business.GroceryList;
using OH.Common.GroceryList;
using OH.Common.GroceryList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        
        public async Task<IEnumerable<ShoppingList>> Get(int userId)
        {
            return await _shoppingListService.GetShoppingListByUser(userId);    

        } 

        [HttpPost]
        public async Task<IEnumerable<ShoppingList>> Post(ShoppingList newListEntry)
        {
            return await _shoppingListService.AddShoppingListItem(newListEntry);
        }

        [HttpPut]
        public async Task<IEnumerable<ShoppingList>> Put(ShoppingList listRemovalItem)
        {
            return await _shoppingListService.RemoveShoppingListItem(listRemovalItem);
        }
    }
}
