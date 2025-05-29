using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Cinema.Movies.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Movies.Queries;

/// <summary>
/// Получение фильмов по жанру
/// </summary>
public sealed class GetMoviesByGenreQuery : IRequest<MovieDto[]>
{
    /// <summary>
    /// Идентификатор жанра
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnGenre { get; init; }
}

public sealed class GetMoviesByGenreQueryHandler : IRequestHandler<GetMoviesByGenreQuery, MovieDto[]>
{
    private readonly DataContext _dataContext;

    public GetMoviesByGenreQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MovieDto[]> Handle(GetMoviesByGenreQuery request, CancellationToken cancellationToken)
    {
        if (!await _dataContext.Genres.AnyAsync(x => x.IsnGenre == request.IsnGenre, cancellationToken))
            throw new BusinessLogicException($"Жанр с идентификатором \"{request.IsnGenre}\" не существует");

        return await _dataContext.MovieGenres
            .AsNoTracking()
            .Where(x => x.IsnGenre == request.IsnGenre)
            .Select(x => new MovieDto
            {
                IsnMovie = x.Movie.IsnMovie,
                Title = x.Movie.Title,
                Description = x.Movie.Description,
                Duration = x.Movie.Duration,
                Rating = x.Movie.Rating,
                Year = x.Movie.Year,
                Country = x.Movie.Country,
                AgeRating = x.Movie.AgeRating,
                IsActive = x.Movie.IsActive,
                CreatedAt = x.Movie.CreatedAt
            })
            .OrderByDescending(x => x.Rating)
            .ThenBy(x => x.Title)
            .ToArrayAsync(cancellationToken);
    }
}