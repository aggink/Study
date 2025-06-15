using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Photography;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.Photography.Sessions.Commands;

/// <summary>
/// Удаление фотосессии
/// </summary>
public sealed class DeletePhotographySessionCommand : IRequest
{
    /// <summary>
    /// Идентификатор фотосессии
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnPhotographySession { get; init; }
}

public sealed class DeletePhotographySessionCommandHandler : IRequestHandler<DeletePhotographySessionCommand>
{
    private readonly DataContext _dataContext;
    private readonly IPhotographySessionService _sessionService;

    public DeletePhotographySessionCommandHandler(
        DataContext dataContext,
        IPhotographySessionService sessionService)
    {
        _dataContext = dataContext;
        _sessionService = sessionService;
    }

    public async Task Handle(DeletePhotographySessionCommand request, CancellationToken cancellationToken)
    {
        var session = await _dataContext.PhotographySessions
                          .FirstOrDefaultAsync(x => x.IsnPhotographySession == request.IsnPhotographySession,
                              cancellationToken)
                      ?? throw new BusinessLogicException(
                          $"Фотосессия с идентификатором \"{request.IsnPhotographySession}\" не существует");

        await _sessionService.CanDeleteAndThrowAsync(_dataContext, session, cancellationToken);

        _dataContext.PhotographySessions.Remove(session);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}