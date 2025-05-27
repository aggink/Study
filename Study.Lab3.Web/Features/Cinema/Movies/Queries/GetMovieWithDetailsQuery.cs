using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Extensions.Cinema;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Enums.Cinema;
using Study.Lab3.Web.Features.Cinema.Movies.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Movies.Queries;

/// <summary>
/// Получение фильма с детальной информацией
/// </summary>
public sealed class GetMovieWithDetailsQuery : IRequest<MovieWithDetailsDto>
{
    /// <summary>
    /// Идентификатор фильма
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnMovie { get; init; }
}

public sealed class GetMovieWithDetailsQueryHandler : IRequestHandler<GetMovieWithDetailsQuery, MovieWithDetailsDto>
{
    private readonly DataContext _dataContext;

    public GetMovieWithDetailsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MovieWithDetailsDto> Handle(GetMovieWithDetailsQuery request, CancellationToken cancellationToken)
    {
        var movie = await _dataContext.Movies
            .AsNoTracking()
            .Include(x => x.MovieGenres)
                .ThenInclude(x => x.Genre)
            .Include(x => x.Sessions)
                .ThenInclude(x => x.Tickets)
            .FirstOrDefaultAsync(x => x.IsnMovie == request.IsnMovie, cancellationToken)
            ?? throw new BusinessLogicException(
                $"Фильм с идентификатором \"{request.IsnMovie}\" не существует");

        var totalTickets = movie.Sessions
            .SelectMany(s => s.Tickets)
            .Where(t => t.Status != TicketStatus.Cancelled)
            .ToList();

        return new MovieWithDetailsDto
        {
            IsnMovie = movie.IsnMovie,
            Title = movie.Title,
            Description = movie.Description,
            Duration = movie.Duration,
            DurationString = movie.GetDurationString(),
            Rating = movie.Rating,
            Year = movie.Year,
            Country = movie.Country,
            AgeRating = movie.AgeRating,
            AgeRatingString = movie.GetAgeRatingString(),
            IsActive = movie.IsActive,
            CreatedAt = movie.CreatedAt,
            Genres = movie.MovieGenres
                .Where(mg => mg.Genre != null)
                .Select(mg => new GenreItemDto
                {
                    IsnGenre = mg.Genre.IsnGenre,
                    Name = mg.Genre.Name
                })
                .OrderBy(g => g.Name)
                .ToArray(),
            SessionsCount = movie.Sessions.Count(s => s.StartTime >= DateTime.UtcNow),
            TotalTicketsSold = totalTickets.Count,
            TotalRevenue = totalTickets.Sum(t => t.Price)
        };
    }
}