using OH.Common.GroceryList;
using OH.Common.GroceryList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OH.UI.GroceryList
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        Task<User> GetUserById(int userId);
        Task<bool> EditUser(int userId);
        Task<bool> DeleteUser(int userId);
    }
}
