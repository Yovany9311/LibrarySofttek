using LibrarySofttek.Domain;
using LibrarySofttek.Repository.Context;
using LibrarySofttek.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibrarySofttek.Repository.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public int Count() => _context.Books.Count();
        public List<Book> GetAll() => _context.Books.Include(b => b.Author).ToList();
        public Book GetBookById(int id)
        {
            return _context.Books.Include(b => b.Author).FirstOrDefault(b => b.Id == id);
        }

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}