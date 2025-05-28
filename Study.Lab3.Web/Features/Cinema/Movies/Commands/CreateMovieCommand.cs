using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Cinema;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Cinema;
using Study.Lab3.Web.Features.Cinema.Movies.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Movies.Commands;

/// <summary>
/// Создание фильма
/// </summary>
public sealed class CreateMovieCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные фильма
    /// </summary>
    [Required]
    [FromBody]
    public CreateMovieDto Movie { get; init; }
}

public sealed class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IMovieService _movieService;

    public CreateMovieCommandHandler(
        DataContext dataContext,
        IMovieService movieService)
    {
        _dataContext = dataContext;
        _movieService = movieService;
    }

    public async Task<Guid> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = new Movie
        {
            IsnMovie = Guid.NewGuid(),
            Title = request.Movie.Title,
            Description = request.Movie.Description,
            Duration = request.Movie.Duration,
            Rating = request.Movie.Rating,
            Year = request.Movie.Year,
            Country = request.Movie.Country,
            AgeRating = request.Movie.AgeRating,
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            MovieGenres = new List<MovieGenre>()
        };

        await _movieService.CreateOrUpdateMovieValidateAndThrowAsync(
            _dataContext, movie, cancellationToken);

        await _dataContext.Movies.AddAsync(movie, cancellationToken);

        // Добавление жанров
        if (request.Movie.GenreIds != null && request.Movie.GenreIds.Length > 0)
        {
            foreach (var genreId in request.Movie.GenreIds)
            {
                var movieGenre = new MovieGenre
                {
                    IsnMovie = movie.IsnMovie,
                    IsnGenre = genreId
                };

                await _movieService.AddGenreValidateAndThrowAsync(
                    _dataContext, movieGenre, cancellationToken);

                await _dataContext.MovieGenres.AddAsync(movieGenre, cancellationToken);
            }
        }

        await _dataContext.SaveChangesAsync(cancellationToken);
        return movie.IsnMovie;
    }
}