using System;
using System.Collections.Generic;

#nullable disable

namespace OH.Common.GroceryList.Models
{
    public partial class ShoppingList
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int UserId { get; set; }
        public int IsDeleted { get; set; }
        public int Amount { get; set; }


        public virtual User User { get; set; }
    }
}
