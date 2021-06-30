using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OH.Common.GroceryList
{
    public class ExtendedUser : Old_User
    {
        public string SocialSecurityNumber { get; set; }
    }

    public class Old_User
    {
        
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int IsDeleted { get; set; }
        /*public string Item { get; set; }
        public string Amount { get; set; }*/
        public Dictionary<string, int> ShoppingCart { get; set; }


        public Old_User()
        {
        }

        public Old_User(int userId, string name)
        {
            UserId = userId;
            Name = name;
        }

        //static void Main(string[] args)
        //{
        //    User Person = new User(); //instatiate

        //    Person.AddMember(Person);
            
        //}

        //public void AddMember(User Person)
        //{
        //    Members membership = new Members();
        //    membership.AddMemberToList(Person);
        //    //Members.AddMemberToList( User Person);
            
        //}
    }

    // This isn't really used
    //public class Cart
    //{
        
    //    public string GroceryItem { get; set; }
    //    public int GroceryItemAmount { get; set; }
    //    public Dictionary<string, int> ShopCart { get; set; }

    //    public void Add(string GroceryItem, int GroceryItemAmount)
    //    {
    //        ShopCart.Add(GroceryItem, GroceryItemAmount);
    //    }
    //}
}
