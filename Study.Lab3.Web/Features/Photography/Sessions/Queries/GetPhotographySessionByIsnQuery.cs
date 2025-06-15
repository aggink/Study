using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Photography.Sessions.DtoModels;

namespace Study.Lab3.Web.Features.Photography.Sessions.Queries;

/// <summary>
/// Получение фотосессии по идентификатору
/// </summary>
public sealed class GetPhotographySessionByIsnQuery : IRequest<PhotographySessionDto>
{
    /// <summary>
    /// Идентификатор фотосессии
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnPhotographySession { get; init; }
}

public sealed class GetPhotographySessionByIsnQueryHandler : IRequestHandler<GetPhotographySessionByIsnQuery, PhotographySessionDto>
{
    private readonly DataContext _dataContext;

    public GetPhotographySessionByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PhotographySessionDto> Handle(GetPhotographySessionByIsnQuery request, CancellationToken cancellationToken)
    {
        var session = await _dataContext.PhotographySessions
                          .AsNoTracking()
                          .FirstOrDefaultAsync(x => x.IsnPhotographySession == request.IsnPhotographySession,
                              cancellationToken)
                      ?? throw new BusinessLogicException(
                          $"Фотосессия с идентификатором \"{request.IsnPhotographySession}\" не существует");

        return new PhotographySessionDto
        {
            IsnPhotographySession = session.IsnPhotographySession,
            Title = session.Title,
            SessionDate = session.SessionDate,
            Duration = session.Duration,
            Location = session.Location,
            Price = session.Price,
            PhotographerName = session.PhotographerName,
            PhotographySessionType = session.PhotographySessionType,
            Status = session.Status,
            Description = session.Description,
            PhotoCount = session.PhotoCount
        };
    }
}