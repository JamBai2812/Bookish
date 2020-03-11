namespace Bookish.Models.Models
{
    public class BookModel
    {
        private Book _book;

        public BookModel(Book book)
        {
            _book = book;

            // AuthorFirstName = book.AuthorFirstName;
        }

        public string AuthorFirstName => _book.AuthorFirstName;
    }
}