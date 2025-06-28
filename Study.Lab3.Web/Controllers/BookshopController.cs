using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.Bookshop.BookshopBooks.Commands;
using Study.Lab3.Web.Features.Bookshop.BookshopBooks.Queries;
using Study.Lab3.Web.Features.Bookshop.BookshopAuthor.Commands;
using Study.Lab3.Web.Features.Bookshop.BookshopAuthor.Queries;
using Study.Lab3.Web.Features.Bookshop.BookshopGenre.Commands;
using Study.Lab3.Web.Features.Bookshop.BookshopGenre.Queries;

namespace Study.Lab3.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookshopController : ControllerBase
{
    private readonly IMediator _mediator;
    public BookshopController(IMediator mediator) => _mediator = mediator;

    // ---------- BOOK ----------
    [HttpGet("books")]
    public async Task<IActionResult> GetBooks() =>
        Ok(await _mediator.Send(new GetBookshopBooksQuery()));

    [HttpGet("books/{id:int}")]
    public async Task<IActionResult> GetBook(int id) =>
        Ok(await _mediator.Send(new GetBookshopBookByIdQuery(id)));

    [HttpPost("books")]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookshopBookCommand cmd) =>
        Ok(await _mediator.Send(cmd));

    [HttpPut("books/{id:int}")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookshopBookCommand cmd)
    { cmd.BookId = id;  return Ok(await _mediator.Send(cmd)); }

    [HttpDelete("books/{id:int}")]
    public async Task<IActionResult> DeleteBook(int id) =>
        Ok(await _mediator.Send(new DeleteBookshopBookCommand(id)));

    // ---------- AUTHOR ----------
    [HttpGet("authors")]
    public async Task<IActionResult> GetAuthors() =>
        Ok(await _mediator.Send(new GetBookshopAuthorsQuery()));

    [HttpGet("authors/{id:int}")]
    public async Task<IActionResult> GetAuthor(int id) =>
        Ok(await _mediator.Send(new GetBookshopAuthorByIdQuery(id)));

    [HttpPost("authors")]
    public async Task<IActionResult> CreateAuthor([FromBody] CreateBookshopAuthorCommand cmd) =>
        Ok(await _mediator.Send(cmd));

    [HttpPut("authors/{id:int}")]
    public async Task<IActionResult> UpdateAuthor(int id, [FromBody] UpdateBookshopAuthorCommand cmd)
    { cmd.AuthorId = id; return Ok(await _mediator.Send(cmd)); }

    [HttpDelete("authors/{id:int}")]
    public async Task<IActionResult> DeleteAuthor(int id) =>
        Ok(await _mediator.Send(new DeleteBookshopAuthorCommand(id)));

    // ---------- GENRE ----------
    [HttpGet("genres")]
    public async Task<IActionResult> GetGenres() =>
        Ok(await _mediator.Send(new GetBookshopGenresQuery()));

    [HttpGet("genres/{id:int}")]
    public async Task<IActionResult> GetGenre(int id) =>
        Ok(await _mediator.Send(new GetBookshopGenreByIdQuery(id)));

    [HttpPost("genres")]
    public async Task<IActionResult> CreateGenre([FromBody] CreateBookshopGenreCommand cmd) =>
        Ok(await _mediator.Send(cmd));

    [HttpPut("genres/{id:int}")]
    public async Task<IActionResult> UpdateGenre(int id, [FromBody] UpdateBookshopGenreCommand cmd)
    { cmd.GenreId = id;  return Ok(await _mediator.Send(cmd)); }

    [HttpDelete("genres/{id:int}")]
    public async Task<IActionResult> DeleteGenre(int id) =>
        Ok(await _mediator.Send(new DeleteBookshopGenreCommand(id)));
}
