using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Shelter.MiniPigAdoptions.Commands;

public sealed class DeleteMiniPigAdoptionCommand : IRequest
{
    /// <summary>
    /// Идентификатор усыновления
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnAdoption { get; init; }
}

/// <summary>
/// Обработчик удаления усыновления
/// </summary>
public sealed class DeleteMiniPigAdoptionCommandHandler : IRequestHandler<DeleteMiniPigAdoptionCommand>
{
    private readonly DataContext _dataContext;

    public DeleteMiniPigAdoptionCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(DeleteMiniPigAdoptionCommand request, CancellationToken cancellationToken)
    {
        var adoption = await _dataContext.Adoptions
            .FirstOrDefaultAsync(a => a.IsnAdoption == request.IsnAdoption, cancellationToken)
            ?? throw new BusinessLogicException($"Усыновление с идентификатором \"{request.IsnAdoption}\" не существует");

        _dataContext.Adoptions.Remove(adoption);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}