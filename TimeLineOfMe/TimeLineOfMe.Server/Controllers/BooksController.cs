using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using TimeLineOfMe.Application.Services;
using TimeLineOfMe.Core.Models;
using TimeLineOfMe.Server.Contracts;

namespace TimeLineOfMe.Server.Controllers;


[ApiController]
[Route("[controller]")]
public class BooksController: ControllerBase
{
    
    private readonly IBooksService _booksService;
    public BooksController(IBooksService booksService)
    {
        _booksService = booksService;
    }


    [HttpGet]
    public async Task<ActionResult<List<BooksResponse>>> GetBooks()
    {
        var books = await _booksService.GetAllBooks();

        var response = books.Select(book => new BooksResponse
        (
            book.Id,
            book.Title,
            book.Author,
            book.Description,
            book.PublishedDate
        ));

        return Ok(response);
    }


    [HttpPost]
    public async Task<ActionResult<Guid>> CreateBook([FromBody] BooksRequest request)
    {

        var (book, error) = Book.Create(
            Guid.NewGuid(),
            request.Title,
            request.Author,
            request.Description,
            request.PublishedDate
            );

        if(!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }

        var createdBookId = await _booksService.CreateBook(book);

        return Ok(createdBookId);

    }


    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateBook(Guid id, [FromBody] BooksRequest request)
    {
        var (book, error) = Book.Create(
            id,
            request.Title,
            request.Author,
            request.Description,
            request.PublishedDate
            );
        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }
        var updatedBookId = await _booksService.UpdateBook(
            id,
            book.Title,
            book.Author,
            book.Description,
            book.PublishedDate
            );
        return Ok(updatedBookId);
    }


    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteBook(Guid id)
    {
        var deletedBookId = await _booksService.DeleteBook(id);
        return Ok(deletedBookId);
    }

}
