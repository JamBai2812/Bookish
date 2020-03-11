using System.Collections.Generic;

namespace Bookish.Models
{
    public class Catalogue
    {
        public List<Book> BookList { get; set; }
        public Catalogue(List<Book> bookList)
        {
            BookList = bookList;
        }

        
        
        
        
    }
}