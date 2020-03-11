using System;
using System.Collections.Generic;
using System.Data;
using Bookish.Models;
using System.Data.SqlClient;
using Dapper;

namespace Bookish.Data
{
    public class BookFetcher
    {
        public List<Book> ReadAllBooks()
        {
            var connectionString = "jdbc:mysql://localhost:3306/BookishDB";

            using (SqlConnection connection  = new SqlConnection(connectionString))
            {
                var eventName = connection.QueryFirst<string>("SELECT TOP 1 EventName FROM Event WHERE Id = 1");
                Console.WriteLine(eventName);
                Console.ReadLine();
            }
        }
        }
    }