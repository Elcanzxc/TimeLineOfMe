
using Microsoft.EntityFrameworkCore;
using TimeLineOfMe.Core.Models;

namespace TimeLineOfMe.DataAccess.Repositories;

public class BookRepoistory
{
    private readonly TimeLineOfMeDbContext _context;
    public BookRepoistory(TimeLineOfMeDbContext context)
    {
        _context = context;
    }


    public async Task<List<Book>> Get()
    {


        var bookEntities = await _context.Books
            .AsNoTracking()
            .ToListAsync();


        var books = bookEntities
            .Select(b => Book.Create(
                b.Id,
                b.Title,
                b.Author,
                b.Description,
                b.PublishedDate))
            .ToList();

        return books;

    }


    public async Task<Guid> Create(Book book)
    {
        var bookEntity = new Entitites.BookEntity
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Description = book.Description,
            PublishedDate = book.PublishedDate
        };
        await _context.Books.AddAsync(bookEntity);

        await  _context.SaveChangesAsync();

        return bookEntity.Id;
    }

    public async Task<Guid> Update(Guid id,string title, string author, string? description, DateTime publishedDate)
    {

        await _context.Books
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(b => b
                .SetProperty(b => b.Title, title)
                .SetProperty(b => b.Author, author)
                .SetProperty(b => b.Description, description)
                .SetProperty(b => b.PublishedDate, publishedDate));


     
        return id;
    }


    public async Task<Guid> Delete(Guid id)
    {
        await _context.Books
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }

}
