using LibrarySofttek.Domain;
using LibrarySofttek.DTOs;
using LibrarySofttek.Exceptions;
using LibrarySofttek.Repository.Interfaces;
using LibrarySofttek.Service.Interfaces;
namespace LibrarySofttek.Service.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly int _maxBooks = 100;

        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public void AddBook(BookDTO bookDto)
        {
            if (_bookRepository.Count() >= _maxBooks)
                throw new Exception("No es posible registrar el libro, se alcanzó el máximo permitido.");

            var author = _authorRepository.GetById(bookDto.AuthorId);
            if (author == null)
                throw new Exception("El autor no está registrado");

            var book = new Book
            {
                Title = bookDto.Title,
                Year = bookDto.Year,
                Genre = bookDto.Genre,
                PageCount = bookDto.PageCount,
                AuthorId = bookDto.AuthorId
            };

            _bookRepository.Add(book);
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }
        public Book GetBookById(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
                throw new BusinessException("⚠️ Libro no encontrado.");

            return book;
        }
        public void UpdateBook(int id, BookDTO bookDto)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
                throw new BusinessException("⚠️ Libro no encontrado.");

            book.Title = bookDto.Title;
            book.Year = bookDto.Year;
            book.Genre = bookDto.Genre;
            book.PageCount = bookDto.PageCount;
            book.AuthorId = bookDto.AuthorId;

            _bookRepository.UpdateBook(book);
        }

        public void DeleteBook(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
                throw new BusinessException("⚠️ Libro no encontrado.");

            _bookRepository.DeleteBook(id);
        }

    }
}