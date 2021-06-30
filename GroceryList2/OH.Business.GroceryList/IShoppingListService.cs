using OH.Common.GroceryList;
using OH.Common.GroceryList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OH.Business.GroceryList
{
    public interface IShoppingListService
    {

        Task<List<User>> GetShoppingList();
        Task<List<User>> GetShoppingUserList();
        Task<List<ShoppingList>> GetShoppingListByUser(int userId);
        Task<List<ShoppingList>> AddShoppingListItem(ShoppingList newListEntry);
        Task<List<ShoppingList>> RemoveShoppingListItem(ShoppingList listRemovalItem);
       
    }
}
