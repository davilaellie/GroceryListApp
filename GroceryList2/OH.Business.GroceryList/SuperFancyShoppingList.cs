using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OH.Business.GroceryList
{
    public class SuperFancyShoppingList : IShoppingListService
    {
        public List<string> GetShoppingList()
        {
            return new List<string>() { "I don't have anything here" };
        }

        public List<string> GetShoppingListByUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
