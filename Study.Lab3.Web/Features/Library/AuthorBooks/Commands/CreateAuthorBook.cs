using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Library;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Library.AuthorBooks.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Library.AuthorBooks.Commands;

/// <summary>
/// Создание связи автор-книга
/// </summary>
public sealed class CreateAuthorBookCommand : IRequest
{
    /// <summary>
    /// Данные связи
    /// </summary>
    [Required]
    [FromBody]
    public CreateAuthorBookDto AuthorBook { get; init; }
}

public sealed class CreateAuthorBookCommandHandler : IRequestHandler<CreateAuthorBookCommand>
{
    private readonly DataContext _dataContext;
    private readonly IAuthorBookService _authorBookService;

    public CreateAuthorBookCommandHandler(DataContext dataContext, IAuthorBookService authorBookService)
    {
        _dataContext = dataContext;
        _authorBookService = authorBookService;
    }

    public async Task Handle(CreateAuthorBookCommand request, CancellationToken cancellationToken)
    {
        var authorBook = new Storage.Models.Library.AuthorBooks
        {
            IsnAuthor = request.AuthorBook.IsnAuthor,
            IsnBook = request.AuthorBook.IsnBook
        };

        await _authorBookService.CreateAuthorBookValidateAndThrowAsync(_dataContext, authorBook, cancellationToken);

        await _dataContext.AuthorBooks.AddAsync(authorBook, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}