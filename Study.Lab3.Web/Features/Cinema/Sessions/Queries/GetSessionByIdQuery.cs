using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Cinema.Sessions.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Sessions.Queries;

/// <summary>
/// Получение сеанса по идентификатору
/// </summary>
public sealed class GetSessionByIdQuery : IRequest<SessionDto>
{
    /// <summary>
    /// Идентификатор сеанса
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnSession { get; init; }
}

public sealed class GetSessionByIdQueryHandler : IRequestHandler<GetSessionByIdQuery, SessionDto>
{
    private readonly DataContext _dataContext;

    public GetSessionByIdQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<SessionDto> Handle(GetSessionByIdQuery request, CancellationToken cancellationToken)
    {
        var session = await _dataContext.Sessions
                          .AsNoTracking()
                          .Include(x => x.Movie)
                          .Include(x => x.Hall)
                          .FirstOrDefaultAsync(x => x.IsnSession == request.IsnSession, cancellationToken)
                      ?? throw new BusinessLogicException(
                          $"Сеанс с идентификатором \"{request.IsnSession}\" не существует");

        return new SessionDto
        {
            IsnSession = session.IsnSession,
            IsnMovie = session.IsnMovie,
            MovieTitle = session.Movie.Title,
            IsnHall = session.IsnHall,
            HallName = session.Hall.Name,
            StartTime = session.StartTime,
            EndTime = session.EndTime,
            BasePrice = session.BasePrice,
            IsActive = session.IsActive
        };
    }
}