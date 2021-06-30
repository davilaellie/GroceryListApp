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
    public class ShoppingListService : IShoppingListService

    {
        private readonly PeopleSQLitedbContext _context;
        
        public ShoppingListService(PeopleSQLitedbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetShoppingList()
        {
            var userslist = await _context.Users.Where(u => u.IsDeleted == 0).ToListAsync();

            return userslist;
        }

        public async Task<List<ShoppingList>> GetShoppingListByUser(int userId)
        {

            return await _context.ShoppingLists
                .Where(u => u.UserId == userId && u.IsDeleted == 0)
                .Select(l => new ShoppingList() { Id = l.Id, UserId = l.UserId, ItemName = l.ItemName, Amount = l.Amount })
                .ToListAsync();


        }

        public async Task<List<ShoppingList>> AddShoppingListItem(ShoppingList newListEntry)
        {
            var user = await _context.Users.Where(u => u.Id == newListEntry.UserId && u.IsDeleted == 0).FirstOrDefaultAsync();

            if (user == null)
            {
                return new List<ShoppingList>();
            }
            else
            {           

                _context.ShoppingLists.Add(newListEntry);
                await _context.SaveChangesAsync();

                // Now, return the full user shopping list.
                var userGroceryList = await _context.ShoppingLists.Where(u => u.UserId == newListEntry.UserId && u.IsDeleted == 0)
                    .Select(l => new ShoppingList() { Id = l.Id, UserId = l.UserId, ItemName = l.ItemName, Amount = l.Amount })
                    .ToListAsync();
                return userGroceryList;
            }

        }
        // Return bool instead of Shopping List
        public async Task<List<ShoppingList>> RemoveShoppingListItem(ShoppingList listRemovalItem)
        {

            //var itemToBeChanged = await _context.ShoppingLists.Where(u => u.ItemName == listRemovalItem.ItemName && u.Amount == listRemovalItem.Amount).FirstOrDefaultAsync();
            //itemToBeChanged.IsDeleted = 1;

            // Do this via item id instead
            var itemToBeChanged = await _context.ShoppingLists.Where(u => u.Id == listRemovalItem.Id).FirstOrDefaultAsync();

            itemToBeChanged.IsDeleted = 1;
            
            await _context.SaveChangesAsync();

            //boxing-unboxing / casting
            // Use item id

            var userGroceryList = await _context.ShoppingLists.Where(u => u.UserId == listRemovalItem.UserId && u.IsDeleted == 0)
                   .Select(l => new ShoppingList() { Id = l.Id, ItemName = l.ItemName, Amount = l.Amount })
                   .ToListAsync();
            return userGroceryList;
        }

        public Task<List<User>> GetShoppingUserList()
        {                        
            return null;
        }

    }
}
