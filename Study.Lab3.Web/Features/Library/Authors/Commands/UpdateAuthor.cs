using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Library;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Library.Authors.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Library.Authors.Commands;

/// <summary>
/// Редактирование автора
/// </summary>
public sealed class UpdateAuthorCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные автора
    /// </summary>
    [Required]
    [FromBody]
    public UpdateAuthorDto Author { get; init; }
}

public sealed class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IAuthorService _authorService;

    public UpdateAuthorCommandHandler(DataContext dataContext, IAuthorService authorService)
    {
        _dataContext = dataContext;
        _authorService = authorService;
    }

    public async Task<Guid> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await _dataContext.Authors.FirstOrDefaultAsync(x => x.IsnAuthor == request.Author.IsnAuthor, cancellationToken)
            ?? throw new BusinessLogicException($"Автора с идентификатором \"{request.Author.IsnAuthor}\" не существует");

        author.SurName = request.Author.SurName;
        author.Name = request.Author.Name;
        author.PatronymicName = request.Author.PatronymicName;
        author.Sex = request.Author.Sex;
        author.IsnTeacher = request.Author.IsnTeacher;

        await _authorService.CreateOrUpdateAuthorValidateAndThrowAsync(_dataContext, author, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return author.IsnAuthor;
    }
}
