using System;
using System.Collections.Generic;

#nullable disable

namespace OH.Common.GroceryList.Models
{
    public partial class User
    {
        public User()
        {
            ShoppingLists = new HashSet<ShoppingList>();           
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long? IsDeleted { get; set; }

        public virtual ICollection<ShoppingList> ShoppingLists { get; set; }        
    }
}
