using Microsoft.AspNetCore.Mvc;

namespace Bookish.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public int YearPublished { get; set; } 
        public int NumberCheckedOut { get; set; }
        public int NumberInStock { get; set; }
    }
}