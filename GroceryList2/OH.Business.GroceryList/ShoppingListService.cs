using OH.Common.GroceryList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OH.Business.GroceryList
{
    public class ShoppingListService : IShoppingListService
    {
        Dictionary<string, int> user1List { get; set; } = new Dictionary<string, int>() {{"Apples", 2 }};

        Dictionary<string, int> user2List { get; set; } = new Dictionary<string, int>() { { "Oranges", 5 } };

        public Dictionary<string, Dictionary<string, int>> GetShoppingList()
        {
            // Need to hook this up to a SQL Database, because new users cannot be added
            var globalList = new Dictionary<string, Dictionary<string, int>>();
            globalList.Add("user1List", user1List );
            globalList.Add("user2List", user2List);

            return globalList;
        }

        public Dictionary<string, int> GetShoppingListByUser(int userId)
        {
            if (userId == 1)
            {
                return user1List;
            }   
            
            if(userId == 2)
            {
                return user2List;
            }

            return new Dictionary<string, int>();
        }

        public Dictionary<string, int> AddShoppingListItem(int userId, string item, int amount)
        {
            
            var entireList = GetShoppingList();
            Dictionary<string, int> userList = null;
            
            if (entireList.ContainsKey("userId"))
            {
                userList = entireList["userId"];
                userList.Add(item, amount);

                return userList;
            }
            // Need to implement a user not being in the system and adding a user

            return new Dictionary<string, int>();


        }

        public List<User> GetShoppingUserList()
        {
            var globalList = new List<User>();
            //globalList.Add("user1List", user1List);
            //globalList.Add("user2List", user2List);

            return globalList;
        }

        /*public Dictionary<string, int> CreateNewUser(int newUserId)
        {
            var entireList = GetShoppingList();

            Dictionary<string, int> newUserList = null;

            string stringNewUserId = newUserId.ToString();

            entireList.Add(stringNewUserId, newUserList);

            return newUserList;
        } */
    }
}
