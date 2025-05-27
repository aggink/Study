using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Library;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Library.Authors.DtoModels;
using Study.Lab3.Web.Features.Library.Books.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Library.Authors.Commands;

/// <summary>
/// Создание связи книги с автором
/// </summary>
public sealed class AddBookAndAuthorCommand : IRequest
{
    /// <summary>
    /// Данные книги
    /// </summary>
    [Required]
    [FromBody]
    public UpdateBookDto Book { get; init; }

    /// <summary>
    /// Данные автора
    /// </summary>
    [Required]
    [FromBody]
    public UpdateAuthorDto Author { get; init; }
}

public sealed class AddBookAndAuthorCommandHandler : IRequest<AddBookAndAuthorCommand>
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
        var book = await _dataContext.Books.FirstOrDefaultAsync(x => x.IsnBook == request.Book.IsnBook, cancellationToken)
            ?? throw new BusinessLogicException($"Книги с идентификатором \"{request.Book.IsnBook}\" не существует");

        var author = await _dataContext.Authors.FirstOrDefaultAsync(x => x.IsnAuthor == request.Author.IsnAuthor, cancellationToken)
            ?? throw new BusinessLogicException($"Автора с идентификатором \"{request.Author.IsnAuthor}\" не существует");

        if (await _dataContext.AuthorBooks.AnyAsync(x => x.IsnBook == request.Book.IsnBook && x.IsnAuthor == request.Author.IsnAuthor, cancellationToken))
            throw new BusinessLogicException($"Книга с идентификатором \"{request.Book.IsnBook}\" уже привязана к автору с идентификатором \"{request.Author.IsnAuthor}\"");

        book.Title = request.Book.Title;
        book.PublicationYear = request.Book.PublicationYear;

        await _bookService.CreateOrUpdateBookValidateAndThrowAsync(_dataContext, book, cancellationToken);

        author.SurName = request.Author.SurName;
        author.Name = request.Author.Name;
        author.PatronymicName = request.Author.PatronymicName;
        author.Sex = request.Author.Sex;
        author.IsnTeacher = request.Author.IsnTeacher;

        await _authorService.CreateOrUpdateAuthorValidateAndThrowAsync(_dataContext, author, cancellationToken);

        var link = new Storage.Models.Library.AuthorBooks
        {
            IsnAuthor = request.Author.IsnAuthor,
            IsnBook = request.Book.IsnBook
        };

        await _dataContext.AuthorBooks.AddAsync(link, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return;
    }
}