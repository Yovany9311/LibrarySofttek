using LibrarySofttek.Domain;
using LibrarySofttek.DTOs;
namespace LibrarySofttek.Service.Interfaces
{
    public interface IBookService
    {
        void AddBook(BookDTO book);
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void UpdateBook(int id, BookDTO bookDto);
        void DeleteBook(int id);
    }
}
