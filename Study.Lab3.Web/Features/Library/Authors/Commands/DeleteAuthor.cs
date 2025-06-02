using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Library;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Library.Authors.Commands;

/// <summary>
/// Удаление автора
/// </summary>
public sealed class DeleteAuthorCommand : IRequest
{
    /// <summary>
    /// Идентификатор автора
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnAuthor { get; init; }
}

public sealed class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
{
    private readonly DataContext _dataContext;
    private readonly IAuthorService _authorService;

    public DeleteAuthorCommandHandler(DataContext dataContext, IAuthorService authorService)
    {
        _dataContext = dataContext;
        _authorService = authorService;
    }

    public async Task Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await _dataContext.Authors.FirstOrDefaultAsync(x => x.IsnAuthor == request.IsnAuthor, cancellationToken)
           ?? throw new BusinessLogicException($"Автора с идентификатором \"{request.IsnAuthor}\" не существует");

        _dataContext.Authors.Remove(author);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return;
    }
}