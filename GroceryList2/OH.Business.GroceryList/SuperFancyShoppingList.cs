using OH.Common.GroceryList;
using OH.Common.GroceryList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OH.Business.GroceryList
{
    public class SuperFancyShoppingList : IShoppingListService
    {
        public Task<List<User>> GetShoppingList()
        {
            throw new NotImplementedException();
        }

        public Task<List<ShoppingList>> GetShoppingListByUser(int userId)
        {
            throw new NotImplementedException();
        }
        public Task<List<ShoppingList>> AddShoppingListItem(ShoppingList newListEntry)
        {
            throw new NotImplementedException();
        }

        Task<List<User>> IShoppingListService.GetShoppingList()
        {
            return null;
            //throw new NotImplementedException();
        }

        public Task<List<User>> GetShoppingUserList()
        {
            throw new NotImplementedException();
        }

        public Task<List<ShoppingList>> RemoveShoppingListItem(ShoppingList listRemovalItem)
        {
            throw new NotImplementedException();
        }
    }
}
