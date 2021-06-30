using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OH.Common.GroceryList
{
    public class Members
    {
        public static List<Old_User> UserList { get; set; }
        public bool f { get; set; }

        //List<User> MembersList { get; set; } = new List<User>();
        //public Members Member { get; set; }

        public void AddMemberToList(Old_User user)
        {
            UserList.Add(user);
        }
        
        public static List<Old_User> GetMembershipList()
        {
            return UserList;
        }

        public static Old_User GetUserById(int targetId)
        {
            bool userNotFound = DoesUserExist(targetId);
            if (userNotFound == false)
            {
                // Create new user. 
                // Options: 
                // 1. ask the user if they want to create a new user
                // 2. just create a new user
            }

            var targetUser = UserList.Find(person => person.UserId == targetId);
            
            return targetUser;
        }

        // Create new check for the user's existence that returns a bool value.
        public static bool DoesUserExist(int targetId)
        {
            if (UserList?.Any() != true)
            {
                return false;
            }
            try
            {
                
                var targetUser = UserList.FirstOrDefault(person => person.UserId == targetId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
            //var targetUser = UserList.AsQueryable().DefaultIfEmpty(newUserDefault);
            //var targetUser = UserList.FirstOrDefault(person => person.UserId == targetId);


        }
    }
}
