using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OH.Business.GroceryList
{
    public class ShoppingListService : IShoppingListService
    {
        List<string> user1List { get; set; } = new List<string>() { "ABC", "DEF" };
        List<string> user2List { get; set; } = new List<string>() { "MNO", "PQR" };


        public List<string> GetShoppingList()
        {
            var globalList = new List<string>();
            globalList.AddRange(user1List);
            globalList.AddRange(user2List);

            return globalList;
        }

        public List<string> GetShoppingListByUser(int userId)
        {
            if (userId == 1)
            {
                return user1List;
            }   
            
            if(userId == 2)
            {
                return user2List;
            }

            return new List<string>();
        }
    }
}
