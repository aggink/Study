using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Cinema.Sessions.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Sessions.Queries;

/// <summary>
/// Получение сеансов по фильму
/// </summary>
public sealed class GetSessionsByMovieQuery : IRequest<SessionDto[]>
{
    /// <summary>
    /// Идентификатор фильма
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnMovie { get; init; }
}

public sealed class GetSessionsByMovieQueryHandler : IRequestHandler<GetSessionsByMovieQuery, SessionDto[]>
{
    private readonly DataContext _dataContext;

    public GetSessionsByMovieQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<SessionDto[]> Handle(GetSessionsByMovieQuery request, CancellationToken cancellationToken)
    {
        if (!await _dataContext.Movies.AnyAsync(x => x.IsnMovie == request.IsnMovie, cancellationToken))
            throw new BusinessLogicException($"Фильм с идентификатором \"{request.IsnMovie}\" не существует");

        return await _dataContext.Sessions
            .AsNoTracking()
            .Include(x => x.Movie)
            .Include(x => x.Hall)
            .Where(x => x.IsnMovie == request.IsnMovie && x.StartTime >= DateTime.UtcNow)
            .OrderBy(x => x.StartTime)
            .Select(x => new SessionDto
            {
                IsnSession = x.IsnSession,
                IsnMovie = x.IsnMovie,
                MovieTitle = x.Movie.Title,
                IsnHall = x.IsnHall,
                HallName = x.Hall.Name,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                BasePrice = x.BasePrice,
                IsActive = x.IsActive
            })
            .ToArrayAsync(cancellationToken);
    }
}