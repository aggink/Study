using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Library;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Library.Authors.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Library.Authors.Commands;

/// <summary>
/// Создание книги с автором
/// </summary>
public sealed class AddBookAndAuthorCommand : IRequest
{
    /// <summary>
    /// Данные книги и автора
    /// </summary>
    [Required]
    [FromBody]
    public AddBookAndAuthorDto AuthorBook { get; init; }
}

public sealed class AddBookAndAuthorCommandHandler : IRequestHandler<AddBookAndAuthorCommand>
{
    private readonly DataContext _dataContext;
    private readonly IBookService _bookService;
    private readonly IAuthorService _authorService;

    public AddBookAndAuthorCommandHandler(DataContext dataContext, IBookService bookService, IAuthorService authorService)
    {
        _dataContext = dataContext;
        _bookService = bookService;
        _authorService = authorService;
    }

    public async Task Handle(AddBookAndAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = new Storage.Models.Library.Authors
        {
            IsnAuthor = Guid.NewGuid(),
            SurName = request.AuthorBook.SurName,
            Name = request.AuthorBook.Name,
            PatronymicName = request.AuthorBook.PatronymicName,
            Sex = request.AuthorBook.Sex,
            IsnTeacher = request.AuthorBook.IsnTeacher
        };

        await _authorService.CreateOrUpdateAuthorValidateAndThrowAsync(_dataContext, author, cancellationToken);
        await _dataContext.Authors.AddAsync(author, cancellationToken);

        var book = new Storage.Models.Library.Books
        {
            IsnBook = Guid.NewGuid(),
            Title = request.AuthorBook.Title,
            PublicationYear = request.AuthorBook.PublicationYear
        };

        await _bookService.CreateOrUpdateBookValidateAndThrowAsync(_dataContext, book, cancellationToken);
        await _dataContext.Books.AddAsync(book, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        var authorBook = new Storage.Models.Library.AuthorBooks
        {
            IsnAuthor = author.IsnAuthor,
            IsnBook = book.IsnBook
        };

        await _dataContext.AuthorBooks.AddAsync(authorBook, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}