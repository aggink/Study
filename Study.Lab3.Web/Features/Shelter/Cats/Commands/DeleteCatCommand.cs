using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.Shelter.Cats.Commands;

public sealed class DeleteCatCommand : IRequest
{
    /// <summary>
    /// Идентификатор кота
    /// </summary>
    [Required]
    [FromQuery]
    public Guid CatId { get; init; }
}

/// <summary>
/// Обработчик удаления кота
/// </summary>
public sealed class DeleteCatCommandHandler : IRequestHandler<DeleteCatCommand>
{
    private readonly DataContext _dataContext;

    public DeleteCatCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(DeleteCatCommand request, CancellationToken cancellationToken)
    {
        var cat = await _dataContext.Cats
                      .FirstOrDefaultAsync(c => c.IsnCat == request.CatId, cancellationToken)
                  ?? throw new BusinessLogicException($"Кот с идентификатором \"{request.CatId}\" не существует");

        _dataContext.Cats.Remove(cat);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}