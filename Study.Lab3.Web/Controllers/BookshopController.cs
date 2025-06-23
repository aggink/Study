using Microsoft.AspNetCore.Mvc;
using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopBooks.Queries;
using Study.Lab3.Web.Features.Bookshop.BookshopBooks.Commands;
using Study.Lab3.Web.Features.Bookshop.BookshopAuthor.Queries;
using Study.Lab3.Web.Features.Bookshop.BookshopAuthor.Commands;
using Study.Lab3.Web.Features.Bookshop.BookshopGenre.Queries;
using Study.Lab3.Web.Features.Bookshop.BookshopGenre.Commands;


namespace Study.Lab3.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookshopController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookshopController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // BOOKS
    [HttpGet("books")]
    public async Task<IActionResult> GetBooks()
    {
        var result = await _mediator.Send(new GetBookshopBooksQuery());
        return Ok(result);
    }

    [HttpGet("books/{id}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var result = await _mediator.Send(new GetBookshopBookByIdQuery { Id = id });
        return Ok(result);
    }

    [HttpPost("books")]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookshopBookCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("books/{id}")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookshopBookCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("books/{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var result = await _mediator.Send(new DeleteBookshopBookCommand { Id = id });
        return Ok(result);
    }

    // AUTHORS
    [HttpGet("authors")]
    public async Task<IActionResult> GetAuthors()
    {
        var result = await _mediator.Send(new GetBookshopAuthorsQuery());
        return Ok(result);
    }

    [HttpGet("authors/{id}")]
    public async Task<IActionResult> GetAuthorById(int id)
    {
        var result = await _mediator.Send(new GetBookshopAuthorByIdQuery { Id = id });
        return Ok(result);
    }

    [HttpPost("authors")]
    public async Task<IActionResult> CreateAuthor([FromBody] CreateBookshopAuthorCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("authors/{id}")]
    public async Task<IActionResult> UpdateAuthor(int id, [FromBody] UpdateBookshopAuthorCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("authors/{id}")]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        var result = await _mediator.Send(new DeleteBookshopAuthorCommand { Id = id });
        return Ok(result);
    }

    // GENRES
    [HttpGet("genres")]
    public async Task<IActionResult> GetGenres()
    {
        var result = await _mediator.Send(new GetBookshopGenresQuery());
        return Ok(result);
    }

    [HttpGet("genres/{id}")]
    public async Task<IActionResult> GetGenreById(int id)
    {
        var result = await _mediator.Send(new GetBookshopGenreByIdQuery { Id = id });
        return Ok(result);
    }

    [HttpPost("genres")]
    public async Task<IActionResult> CreateGenre([FromBody] CreateBookshopGenreCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("genres/{id}")]
    public async Task<IActionResult> UpdateGenre(int id, [FromBody] UpdateBookshopGenreCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("genres/{id}")]
    public async Task<IActionResult> DeleteGenre(int id)
    {
        var result = await _mediator.Send(new DeleteBookshopGenreCommand { Id = id });
        return Ok(result);
    }
}
