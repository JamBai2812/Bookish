namespace Bookish.Models.Models
{
    public class BookModel
    {
        private Book _book;

        BookModel(Book book)
        {
            _book.Id = book.Id;
            _book.AuthorFirstName = book.AuthorFirstName;
            _book.AuthorLastName = book.AuthorLastName;
            _book.Title = book.Title;
            _book.YearPublished = book.YearPublished;
            _book.NumberCheckedOut = book.NumberCheckedOut;
            _book.NumberInStock = book.NumberInStock;
        }
    }
}