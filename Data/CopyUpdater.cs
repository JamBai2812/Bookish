using System.Collections.Generic;
using System.Linq;
using Bookish.Models;
using Bookish.Models.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace Bookish.Data
{

    public class CopyUpdater
    {
        private string connectionString = "Server=localhost;Database=BookishDB;Uid=root;Pwd=Bparty2568;";

        public void AddCopy(string id)
        {
            string sql =
                "UPDATE catalogue SET number_in_stock = number_in_stock + 1 WHERE book_id = @bookId";
            
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                conn.Execute(sql, new {bookId = id});
            }
        }
        
        public void DeleteCopy(string id)
        {
            string sql =
                "UPDATE catalogue SET number_in_stock = number_in_stock - 1 WHERE book_id = @bookId";
            
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                conn.Execute(sql, new {bookId = id});
            }
        }
    }
}