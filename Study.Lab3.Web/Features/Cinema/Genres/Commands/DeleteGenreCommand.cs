using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Cinema;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Genres.Commands;

/// <summary>
/// Удаление жанра
/// </summary>
public sealed class DeleteGenreCommand : IRequest
{
    /// <summary>
    /// Идентификатор жанра
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnGenre { get; init; }
}

public sealed class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand>
{
    private readonly DataContext _dataContext;
    private readonly IGenreService _genreService;

    public DeleteGenreCommandHandler(
        DataContext dataContext,
        IGenreService genreService)
    {
        _dataContext = dataContext;
        _genreService = genreService;
    }

    public async Task Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = await _dataContext.Genres
                        .FirstOrDefaultAsync(x => x.IsnGenre == request.IsnGenre, cancellationToken)
                    ?? throw new BusinessLogicException(
                        $"Жанр с идентификатором \"{request.IsnGenre}\" не существует");

        await _genreService.CanDeleteAndThrowAsync(
            _dataContext, genre, cancellationToken);

        _dataContext.Genres.Remove(genre);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}