using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OH.Business.GroceryList
{
    public interface IShoppingListService
    {
        List<string> GetShoppingList();
        List<string> GetShoppingListByUser(int userId);
    }
}
