using System.Collections.Generic;
using System.Linq;
using Bookish.Models;
using Bookish.Models.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace Bookish.Data
{
    public interface IAdder
    {
        void AddBook(Book book);
    }

    public class BookAdder : IAdder
    {
        private string connectionString = "Server=localhost;Database=BookishDB;Uid=root;Pwd=Bparty2568;";

        public void AddBook(Book book)
        {
            string sql =
                "INSERT INTO catalogue (author_first_name, author_last_name, title, year_published, number_checked_out, number_in_stock) VALUES (@firstName, @lastName, @title, @yearPublished, 0, 1)";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                conn.Execute(sql, new {firstName = book.AuthorFirstName, lastName = book.AuthorLastName, title = book.Title, yearPublished = book.YearPublished});
            }
        }
    }
}