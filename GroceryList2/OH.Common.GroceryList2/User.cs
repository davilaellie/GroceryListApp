using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OH.Common.GroceryList
{
    public class ExtendedUser : User
    {
        public string SocialSecurityNumber { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        /*public string Item { get; set; }
        public string Amount { get; set; }*/
       
        public Dictionary<string, int> ShoppingCart { get; set; }
        

        
    }
}
