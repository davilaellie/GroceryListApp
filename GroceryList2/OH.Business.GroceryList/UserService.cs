using Microsoft.EntityFrameworkCore;
using OH.Business.GroceryList.Database;
using OH.Common.GroceryList;
using OH.Common.GroceryList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OH.Business.GroceryList
{
    public class UserService : IUserService
    {
        private readonly PeopleSQLitedbContext _context;

        public UserService(PeopleSQLitedbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            user.IsDeleted = 0;

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetUserById(int userId)
        {
            var foundUser = await _context.Users.Where(u => u.Id == userId && u.IsDeleted == 0).FirstOrDefaultAsync();

            if (foundUser == null)
            {
                return new User();
            }

            return foundUser;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var user = await _context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
            
            if (user == null)
                return true;

            user.IsDeleted = 1;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditUser(User user)
        {
            _context.Users.Update(user);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
