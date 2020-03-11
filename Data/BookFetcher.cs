using System;
using System.Collections.Generic;
using System.Data;
using Bookish.Models;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.AspNetCore.HttpOverrides;
using MySql.Data.MySqlClient;

namespace Bookish.Data
{
    public class BookFetcher
    {
        public List<Book> GetAllBooks()
        {
            var server = "localhost";
            var database = "BookishDB";
            var uid = "root";
            var password = "Bparty2568";
            string connectionString = "Server=" + server + ";" + "Database=" + 
                                      database + ";" + "Uid=" + uid + ";" + "Pwd=" + password + ";";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                List<Book> bookList = conn.Query<Book>("SELECT * FROM catalogue").ToList();
                return bookList;
            }
        }
    }
}