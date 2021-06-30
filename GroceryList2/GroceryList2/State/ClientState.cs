using OH.Common.GroceryList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryList2.State
{
    public static class ClientState
    {
        public static int UserId { get; set; }
        public static List<ShoppingList> ShoppingListItems { get; set; } = new List<ShoppingList>();
        public static string Name { get; set; }
        public static string LastName { get; set; }
        public static string Email { get; set; }
        public static User Person { get; set; }
        
    }
}
