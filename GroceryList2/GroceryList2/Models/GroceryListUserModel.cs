using OH.Common.GroceryList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryList2.Models
{
    public class GroceryListUserModel : User
    {
        public List<ShoppingList> ShopLists { get; set; } = new List<ShoppingList>();
    }
}
