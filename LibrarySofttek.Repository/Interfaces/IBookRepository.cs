using LibrarySofttek.Domain;
using System.Collections.Generic;
namespace LibrarySofttek.Repository.Interfaces
{
    public interface IBookRepository
    {
        void Add(Book book);
        int Count();
        List<Book> GetAll();
        Book GetBookById(int id);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}
