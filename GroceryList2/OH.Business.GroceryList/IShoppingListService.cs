using OH.Common.GroceryList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OH.Business.GroceryList
{
    public interface IShoppingListService
    {
        Dictionary<string, Dictionary<string, int>> GetShoppingList();
        List<User> GetShoppingUserList();
        Dictionary<string, int> GetShoppingListByUser(int userId);
        Dictionary<string, int> AddShoppingListItem(int userId, string item, int amount);
        /*Dictionary<string, int> CreateNewUser(int newUserId);*/
    }
}
