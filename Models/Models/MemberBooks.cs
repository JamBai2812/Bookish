using System.Collections.Generic;

namespace Bookish.Models.Models
{
    public class MemberBooks
    {
        public List<MemberBook> MemberBookList { get; set; }
        
        public MemberBooks(List<MemberBook> memberBookList)
        {
            MemberBookList = memberBookList;
        }
    }
}