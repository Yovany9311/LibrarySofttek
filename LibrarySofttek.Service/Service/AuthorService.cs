using LibrarySofttek.Domain;
using LibrarySofttek.DTOs;
using LibrarySofttek.Exceptions;
using LibrarySofttek.Repository.Interfaces;
using LibrarySofttek.Service.Interfaces;

namespace LibrarySofttek.Service.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public void AddAuthor(AuthorDTO authorDto)
        {
            var author = new Author
            {
                FullName = authorDto.FullName,
                BirthDate = authorDto.BirthDate,
                City = authorDto.City,
                Email = authorDto.Email
            };

            _authorRepository.Add(author);
        }

        public Author GetAuthorById(int id)
        {
            return _authorRepository.GetById(id);
        }

        public List<Author> GetAllAuthors()
        {
            return _authorRepository.GetAll();
        }
        public void UpdateAuthor(int id, AuthorDTO authorDto)
        {
            var author = _authorRepository.GetById(id);
            if (author == null)
            {
                throw new BusinessException("El autor no existe.");
            }

            author.FullName = authorDto.FullName;
            author.BirthDate = authorDto.BirthDate;
            author.City = authorDto.City;
            author.Email = authorDto.Email;

            _authorRepository.Update(author);
        }

        public void DeleteAuthor(int id)
        {
            var author = _authorRepository.GetById(id);
            if (author == null)
            {
                throw new BusinessException("El autor no existe.");
            }

            _authorRepository.Delete(id);
        }
    }
}
