using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Photography;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Photography.Sessions.DtoModels;

namespace Study.Lab3.Web.Features.Photography.Sessions.Commands;

/// <summary>
/// Обновление фотосессии
/// </summary>
public sealed class UpdatePhotographySessionCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные фотосессии
    /// </summary>
    [Required]
    [FromBody]
    public UpdatePhotographySessionDto Session { get; init; }
}

public sealed class UpdatePhotographySessionCommandHandler : IRequestHandler<UpdatePhotographySessionCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPhotographySessionService _sessionService;

    public UpdatePhotographySessionCommandHandler(
        DataContext dataContext,
        IPhotographySessionService sessionService)
    {
        _dataContext = dataContext;
        _sessionService = sessionService;
    }

    public async Task<Guid> Handle(UpdatePhotographySessionCommand request, CancellationToken cancellationToken)
    {
        var session = await _dataContext.PhotographySessions
                          .FirstOrDefaultAsync(x => x.IsnPhotographySession == request.Session.IsnPhotographySession,
                              cancellationToken)
                      ?? throw new BusinessLogicException(
                          $"Фотосессия с идентификатором \"{request.Session.IsnPhotographySession}\" не существует");

        session.Title = request.Session.Title;
        session.SessionDate = request.Session.SessionDate;
        session.Duration = request.Session.Duration;
        session.Location = request.Session.Location;
        session.Price = request.Session.Price;
        session.PhotographerName = request.Session.PhotographerName;
        session.PhotographySessionType = request.Session.PhotographySessionType;
        session.Status = request.Session.Status;
        session.Description = request.Session.Description;
        session.PhotoCount = request.Session.PhotoCount;

        await _sessionService.CreateOrUpdateSessionValidateAndThrowAsync(
            _dataContext, session, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return session.IsnPhotographySession;
    }
}
