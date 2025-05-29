using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Library;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Library.Authors.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Library.Authors.Commands;

/// <summary>
/// Создание автора
/// </summary>
public sealed class CreateAuthorCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные автора
    /// </summary>
    [FromBody]
    [Required]
    public CreateAuthorDto Author { get; init; }
}

public sealed class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IAuthorService _authorService;

    public CreateAuthorCommandHandler(DataContext dataContext, IAuthorService authorService)
    {
        _dataContext = dataContext;
        _authorService = authorService;
    }

    public async Task<Guid> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = new Storage.Models.Library.Authors
        {
            IsnAuthor = Guid.NewGuid(),
            SurName = request.Author.Name,
            Name = request.Author.Name,
            PatronymicName = request.Author.Name,
            Sex = request.Author.Sex,
            IsnTeacher = request.Author.IsnTeacher
        };

        await _authorService.CreateOrUpdateAuthorValidateAndThrowAsync(_dataContext, author, cancellationToken);

        await _dataContext.Authors.AddAsync(author, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return author.IsnAuthor;
    }
}