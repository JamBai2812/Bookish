using System.Collections.Generic;

namespace Bookish.Models.Models
{
    public class Members
    {
        public List<Member> MemberList { get; set; }
        public Members(List<Member> memberList)
        {
            MemberList = memberList;
        }
    }
}