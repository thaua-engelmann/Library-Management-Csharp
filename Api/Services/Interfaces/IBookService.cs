using Library_Management.Api.Entities;

namespace Library_Management.Api.Services.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAll();
        void Add(Book book);
    }
}
