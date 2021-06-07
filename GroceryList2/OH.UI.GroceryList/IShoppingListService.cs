using OH.Common.GroceryList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OH.UI.GroceryList
{
    public interface IShoppingListService
    {
        Task<Dictionary<string, int>> GetShoppingList();
        Task<List<User>> GetShoppingUserList();
        Task<Dictionary<string, int>> GetShoppingListByUser(int userId);
        Task<Dictionary<string, int>> AddShoppingListItem(int userId, string item, int amount);
        /*Task<Dictionary<string, int>> CreateNewUser(int newUserId);*/
    }
}
