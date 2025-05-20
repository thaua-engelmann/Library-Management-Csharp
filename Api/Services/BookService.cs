using Library_Management.Api.Entities;
using Library_Management.Api.Services.Interfaces;

namespace Library_Management.Api.Services
{
    public class BookService : IBookService
    {

        private readonly List<Book> _books = new();

        public List<Book> GetAll()
        {
            return _books;
        }

        public void Add(Book book)
        {
            _books.Add(book);
        }

        public Book? Get(Guid id)
        {
            return _books.FirstOrDefault(book => book.Id == id);
        }

    }
}
