using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Photography;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Photography;
using Study.Lab3.Web.Features.Photography.Sessions.DtoModels;

namespace Study.Lab3.Web.Features.Photography.Sessions.Commands;

/// <summary>
/// Создание фотосессии
/// </summary>
public sealed class CreatePhotographySessionCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные фотосессии
    /// </summary>
    [Required]
    [FromBody]
    public CreatePhotographySessionDto Session { get; init; }
}

public sealed class CreatePhotographySessionCommandHandler : IRequestHandler<CreatePhotographySessionCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPhotographySessionService _sessionService;

    public CreatePhotographySessionCommandHandler(
        DataContext dataContext,
        IPhotographySessionService sessionService)
    {
        _dataContext = dataContext;
        _sessionService = sessionService;
    }

    public async Task<Guid> Handle(CreatePhotographySessionCommand request, CancellationToken cancellationToken)
    {
        var session = new PhotographySession
        {
            IsnPhotographySession = Guid.NewGuid(),
            Title = request.Session.Title,
            SessionDate = request.Session.SessionDate,
            Duration = request.Session.Duration,
            Location = request.Session.Location,
            Price = request.Session.Price,
            PhotographerName = request.Session.PhotographerName,
            PhotographySessionType = request.Session.PhotographySessionType,
            Status = request.Session.Status,
            Description = request.Session.Description,
            PhotoCount = request.Session.PhotoCount
        };

        await _sessionService.CreateOrUpdateSessionValidateAndThrowAsync(
            _dataContext, session, cancellationToken);

        await _dataContext.PhotographySessions.AddAsync(session, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return session.IsnPhotographySession;
    }
}