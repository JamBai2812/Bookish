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
        public string AuthorLastName => _book.AuthorLastName;
        public string Title => _book.Title;
        public int YearPublished => _book.YearPublished;
        public int NumberCheckedOut => _book.NumberCheckedOut;
        public int NumberInStock => _book.NumberInStock;
    }
}