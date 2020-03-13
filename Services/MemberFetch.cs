using System;
using System.Collections.Generic;
using System.Data;
using Bookish.Models;
using System.Data.SqlClient;
using System.Linq;
using Bookish.Controllers;
using Dapper;
using Microsoft.AspNetCore.HttpOverrides;
using MySql.Data.MySqlClient;

namespace Bookish.Data
{
    // public enum Sort {
    //     Name, Published
    // }

    public interface IMemberFetcher
    {
        List<Member> AllMembers(string sql);
        // List<Book> GetAllBooks(Sort sort);
    }
    
    public class MemberFetch : IMemberFetcher
    {
        private string connectionString = "Server=localhost;Database=BookishDB;Uid=root;Pwd=Bparty2568;";
        
        public List<Member> AllMembers(string sql)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                List<Member> memberList = conn.Query<Member>(sql).ToList();
                return memberList;
            }
            
        }
    }
}