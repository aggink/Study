using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Shelter.Cats.Commands;

namespace Study.Lab3.Web.Features.Shelter.Adoptions.Commands;

public sealed class DeleteAdoptionCommand : IRequest
{
    /// <summary>
    /// Идентификатор усыновления
    /// </summary>
    [Required]
    [FromQuery]
    public Guid AdoptionId { get; init; }
}

/// <summary>
/// Обработчик удаления усыновления
/// </summary>
public sealed class DeleteAdoptionCommandHandler : IRequestHandler<DeleteAdoptionCommand>
{
    private readonly DataContext _dataContext;

    public DeleteAdoptionCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(DeleteAdoptionCommand request, CancellationToken cancellationToken)
    {
        var adoption = await _dataContext.Adoptions
            .FirstOrDefaultAsync(a => a.Id == request.AdoptionId, cancellationToken)
            ?? throw new BusinessLogicException($"Усыновление с идентификатором \"{request.AdoptionId}\" не существует");

        _dataContext.Adoptions.Remove(adoption);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}