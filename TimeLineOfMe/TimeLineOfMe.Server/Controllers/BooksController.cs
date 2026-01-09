using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using TimeLineOfMe.Application.Services;
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

}
