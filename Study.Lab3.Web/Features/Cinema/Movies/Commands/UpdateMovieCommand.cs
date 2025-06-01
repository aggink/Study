using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Cinema;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Cinema.Movies.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Movies.Commands;

/// <summary>
/// Обновление фильма
/// </summary>
public sealed class UpdateMovieCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные фильма
    /// </summary>
    [Required]
    [FromBody]
    public UpdateMovieDto Movie { get; init; }
}

public sealed class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IMovieService _movieService;

    public UpdateMovieCommandHandler(
        DataContext dataContext,
        IMovieService movieService)
    {
        _dataContext = dataContext;
        _movieService = movieService;
    }

    public async Task<Guid> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _dataContext.Movies
                        .FirstOrDefaultAsync(x => x.IsnMovie == request.Movie.IsnMovie, cancellationToken)
                    ?? throw new BusinessLogicException(
                        $"Фильм с идентификатором \"{request.Movie.IsnMovie}\" не существует");

        movie.Title = request.Movie.Title;
        movie.Description = request.Movie.Description;
        movie.Duration = request.Movie.Duration;
        movie.Rating = request.Movie.Rating;
        movie.Year = request.Movie.Year;
        movie.Country = request.Movie.Country;
        movie.AgeRating = request.Movie.AgeRating;
        movie.IsActive = request.Movie.IsActive;

        await _movieService.CreateOrUpdateMovieValidateAndThrowAsync(
            _dataContext, movie, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return movie.IsnMovie;
    }
}