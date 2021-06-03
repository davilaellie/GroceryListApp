using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OH.UI.GroceryList
{
    public interface IShoppingListService
    {
        Task<List<string>> GetShoppingList();
        Task<List<string>> GetShoppingListByUser(int userId);
    }
}
