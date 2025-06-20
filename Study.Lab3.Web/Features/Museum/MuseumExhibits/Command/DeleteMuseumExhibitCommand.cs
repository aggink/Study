using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Museum;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.Museum.MuseumExhibits.Command;

/// <summary>
/// Удаление экспоната музея
/// </summary>
public sealed class DeleteMuseumExhibitCommand : IRequest
{
    /// <summary>
    /// Идентификатор экспоната
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnMuseumExhibit { get; init; }
}

public sealed class DeleteMuseumExhibitCommandHandler : IRequestHandler<DeleteMuseumExhibitCommand>
{
    private readonly DataContext _dataContext;
    private readonly IMuseumExhibitService _exhibitService;

    public DeleteMuseumExhibitCommandHandler(
        DataContext dataContext,
        IMuseumExhibitService exhibitService)
    {
        _dataContext = dataContext;
        _exhibitService = exhibitService;
    }

    public async Task Handle(DeleteMuseumExhibitCommand request, CancellationToken cancellationToken)
    {
        var exhibit = await _dataContext.MuseumExhibits
                          .FirstOrDefaultAsync(x => x.IsnMuseumExhibit == request.IsnMuseumExhibit, cancellationToken)
                      ?? throw new BusinessLogicException($"Экспонат с идентификатором \"{request.IsnMuseumExhibit}\" не существует");

        await _exhibitService.CanDeleteAndThrowAsync(
            _dataContext, exhibit, cancellationToken);

        _dataContext.MuseumExhibits.Remove(exhibit);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}