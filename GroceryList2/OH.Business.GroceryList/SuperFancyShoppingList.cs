using OH.Common.GroceryList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OH.Business.GroceryList
{
    public class SuperFancyShoppingList : IShoppingListService
    {
        public Dictionary<string, int> GetShoppingList()
        {
            return new Dictionary<string, int>() { { "I don't have anything here", 0 } };
        }

        public Dictionary<string, int> GetShoppingListByUser(int userId)
        {
            throw new NotImplementedException();
        }
        public Dictionary<string, int> AddShoppingListItem(int userId, string item, int amount)
        {
            throw new NotImplementedException();
        }

        Dictionary<string, Dictionary<string, int>> IShoppingListService.GetShoppingList()
        {
            throw new NotImplementedException();
        }

        public List<User> GetShoppingUserList()
        {
            throw new NotImplementedException();
        }
    }
}
