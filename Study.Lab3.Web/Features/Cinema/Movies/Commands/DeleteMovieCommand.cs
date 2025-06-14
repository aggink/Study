using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Cinema;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Movies.Commands;

/// <summary>
/// Удаление фильма
/// </summary>
public sealed class DeleteMovieCommand : IRequest
{
    /// <summary>
    /// Идентификатор фильма
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnMovie { get; init; }
}

public sealed class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
{
    private readonly DataContext _dataContext;
    private readonly IMovieService _movieService;

    public DeleteMovieCommandHandler(
        DataContext dataContext,
        IMovieService movieService)
    {
        _dataContext = dataContext;
        _movieService = movieService;
    }

    public async Task Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _dataContext.Movies
                        .Include(x => x.MovieGenres)
                        .FirstOrDefaultAsync(x => x.IsnMovie == request.IsnMovie, cancellationToken)
                    ?? throw new BusinessLogicException(
                        $"Фильм с идентификатором \"{request.IsnMovie}\" не существует");

        await _movieService.CanDeleteAndThrowAsync(
            _dataContext, movie, cancellationToken);

        // Удаляем связи с жанрами
        _dataContext.MovieGenres.RemoveRange(movie.MovieGenres);

        // Удаляем фильм
        _dataContext.Movies.Remove(movie);

        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}