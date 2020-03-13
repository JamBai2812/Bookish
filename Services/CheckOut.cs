using Bookish.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace Bookish.Data
{
    public interface ICheckOut
    {
        void AddMemberBook(MemberBook memberBook);
    }
    
    public class CheckOut : ICheckOut
    {
        private string connectionString = "Server=localhost;Database=BookishDB;Uid=root;Pwd=Bparty2568;";
        public void AddMemberBook(MemberBook memberBook)
        {
            string sql =
                "INSERT INTO member_book (member_id, book_id) VALUES (@memberId, @bookId)";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                conn.Execute(sql, new {memberId = memberBook.MemberId, bookId = memberBook.BookId});
            }
        }
    }
}