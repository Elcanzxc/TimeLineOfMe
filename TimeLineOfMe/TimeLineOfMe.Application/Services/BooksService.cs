
using TimeLineOfMe.Core.Models;
using TimeLineOfMe.DataAccess.Repositories;

namespace TimeLineOfMe.Application.Services;

public class BooksService : IBooksService
{

    private readonly IBooksRepoistory _booksRepoistory;
    public BooksService(IBooksRepoistory booksRepoistory)
    {
        _booksRepoistory = booksRepoistory;
    }


    public async Task<List<Book>> GetAllBooks()
    {
        return await _booksRepoistory.Get();
    }

    public async Task<Guid> CreateBook(Book book)
    {
        return await _booksRepoistory.Create(book);
    }

    public async Task<Guid> UpdateBook(Guid id, string title, string author, string? description, DateTime publishedDate)
    {
        return await _booksRepoistory.Update(id, title, author, description, publishedDate);
    }

    public async Task<Guid> DeleteBook(Guid id)
    {
        return await _booksRepoistory.Delete(id);
    }


}
