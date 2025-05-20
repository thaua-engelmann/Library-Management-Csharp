using Library_Management.Api.Entities;

namespace Library_Management.Api.Services.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAll();
        Book? Get(Guid id);
        void Add(Book book);
    }
}
