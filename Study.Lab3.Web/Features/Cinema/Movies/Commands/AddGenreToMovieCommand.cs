using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Cinema;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Cinema;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Movies.Commands;

/// <summary>
/// Добавление жанра к фильму
/// </summary>
public sealed class AddGenreToMovieCommand : IRequest
{
    /// <summary>
    /// Идентификатор фильма
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnMovie { get; init; }

    /// <summary>
    /// Идентификатор жанра
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnGenre { get; init; }
}

public sealed class AddGenreToMovieCommandHandler : IRequestHandler<AddGenreToMovieCommand>
{
    private readonly DataContext _dataContext;
    private readonly IMovieService _movieService;

    public AddGenreToMovieCommandHandler(
        DataContext dataContext,
        IMovieService movieService)
    {
        _dataContext = dataContext;
        _movieService = movieService;
    }

    public async Task Handle(AddGenreToMovieCommand request, CancellationToken cancellationToken)
    {
        var movieGenre = new MovieGenre
        {
            IsnMovie = request.IsnMovie,
            IsnGenre = request.IsnGenre
        };

        await _movieService.AddGenreValidateAndThrowAsync(
            _dataContext, movieGenre, cancellationToken);

        await _dataContext.MovieGenres.AddAsync(movieGenre, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}