using TimeLineOfMe.Core.Models;

namespace TimeLineOfMe.DataAccess.Repositories
{
    public interface IBooksRepoistory
    {
        Task<Guid> Create(Book book);
        Task<Guid> Delete(Guid id);
        Task<List<Book>> Get();
        Task<Guid> Update(Guid id, string title, string author, string? description, DateTime publishedDate);
    }
}