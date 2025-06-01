using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Movies.Commands;

/// <summary>
/// Удаление жанра из фильма
/// </summary>
public sealed class RemoveGenreFromMovieCommand : IRequest
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

public sealed class RemoveGenreFromMovieCommandHandler : IRequestHandler<RemoveGenreFromMovieCommand>
{
    private readonly DataContext _dataContext;

    public RemoveGenreFromMovieCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(RemoveGenreFromMovieCommand request, CancellationToken cancellationToken)
    {
        var movieGenre = await _dataContext.MovieGenres
                             .FirstOrDefaultAsync(
                                 x => x.IsnMovie == request.IsnMovie && x.IsnGenre == request.IsnGenre,
                                 cancellationToken)
                         ?? throw new BusinessLogicException(
                             "Указанный жанр не привязан к данному фильму");

        _dataContext.MovieGenres.Remove(movieGenre);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}