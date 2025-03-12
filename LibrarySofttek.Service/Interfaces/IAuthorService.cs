using LibrarySofttek.Domain;
using LibrarySofttek.DTOs;
namespace LibrarySofttek.Service.Interfaces
{
    public interface IAuthorService
    {
        void AddAuthor(AuthorDTO author);
        Author GetAuthorById(int id);
        List<Author> GetAllAuthors();
        void UpdateAuthor(int id, AuthorDTO authorDto);
        void DeleteAuthor(int id);
    }
}
