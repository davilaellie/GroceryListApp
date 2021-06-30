using Dapper;
using Microsoft.AspNetCore.Http;
using OH.Common.GroceryList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// NOTES FOR 06.15.21: 
// -do my parameters for sql queries need to be dynamic?? especially because these values are allowed to be null
//  (see AddUser for reference to this question)
// -do 


namespace OH.Business.GroceryList
{
    public class SQLiteData
    {
        
        // I don't know if this will ever be needed, but it's here just in case it is needed.
        public static List<User> LoadAllMembers()
        {
            // Create connection to the database
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                // Query the database (Check syntax -- I know I shouldn't use * but I don't know what else to use here)
                var output = cnn.Query<User>(
                    "SELECT * From User WHERE IsDeleted = 0" + new DynamicParameters());
                return output.ToList();
                
            }
        }

        // Following is for UserService:
        public static User AddUser(User user)
        {
            
            using(IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    // does this need to be different? unsure of syntax here with @Name, @LastName, etc.
                    cnn.Execute("INSERT into User (Name, LastName, Email, IsDeleted) values (@Name, @LastName, @Email, @IsDeleted)", user);
                    return user;
                }
                catch (Exception)
                {
                    return new User();
                }
            }
        }

        public static bool DeleteUser(int userId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    cnn.Execute("UPDATE ShoppingList SET IsDeleted = 1 WHERE UserId = " + userId);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        // Following is for ShoppingList Service:
        public static Dictionary<string, int> AddGroceryItem(int userId, string item, int amount)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    //Figure out correct syntax here
                    cnn.Execute("INSERT INTO ShoppingList (ItemName, Amount) VALUES (@item, " + @amount + ")" +
                        "WHERE UserId = @userId");
                    
                    var query = "SELECT ItemName AS [Key], Amount AS [Value] FROM ShoppingList WHERE UserId = " + @userId + " AND IsDeleted = 0" +
                     new DynamicParameters();
                    var result = cnn.Query<ShoppingListService>(query).ToDictionary(res => res.ItemName, res => res.Amnt);
                    return result;
                }
                catch (Exception)
                {
                    return new Dictionary<string, int>();
                }
            }
        }

        


        public static Dictionary<string, int> FindUserShoppingList(int userId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))

            {
                var query = "SELECT ItemName AS [Key], Amount AS [Value] FROM ShoppingList WHERE UserId = " + @userId + " AND IsDeleted = 0" +
                     new DynamicParameters();
                var result = cnn.Query<ShoppingListService>(query).ToDictionary(res => res.ItemName, res => res.Amnt);
                return result;

                
                //This is scratch code/practice:

                //var result = cnn.Query<QueryResult<string, int>>(query);
                //return result.ToDictionary();

                //var result = cnn.Database.AsQueryable<QueryResult<string, int>>(query);
                //using (SQLiteCommand command = new SQLiteCommand())
                //{
                //    using (SQLiteDataReader reader = command.ExecuteReader())
                //    {
                //        while (reader.Read())
                //        {
                //            dictionary.Add(reader.GetString(0), reader.GetInt32(1));
                //        }
                //    }
                //}


                

            }
        }
        private static string LoadConnectionString(string id = default)
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }

    //public class QueryResult<T1, T2>
    //{
    //    public string Key { get; set; }
    //    public int Value { get; set; }
    //}

}
