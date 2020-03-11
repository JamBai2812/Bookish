using System;
using System.Collections.Generic;
using System.Data;
using Bookish.Models;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Bookish.Data
{
    public class BookFetcher
    {
        public List<Book> GetAllBooks()
        {
            var connectionString = "jdbc:mysql://localhost:3306/BookishDB";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<Book> bookList = connection.Query<Book>("SELECT * FROM catalogue").ToList();
                return bookList;
            }
        }
    }
}