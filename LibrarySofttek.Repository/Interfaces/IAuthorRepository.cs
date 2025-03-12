using LibrarySofttek.Domain;
namespace LibrarySofttek.Repository.Interfaces
{
    public interface IAuthorRepository
    {
        void Add(Author author);
        Author GetById(int id);
        List<Author> GetAll();
        void Update(Author author);
        void Delete(int id);
    }
}
