using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Cinema;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Cinema.Genres.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Genres.Commands;

/// <summary>
/// Обновление жанра
/// </summary>
public sealed class UpdateGenreCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные жанра
    /// </summary>
    [Required]
    [FromBody]
    public UpdateGenreDto Genre { get; init; }
}

public sealed class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IGenreService _genreService;

    public UpdateGenreCommandHandler(
        DataContext dataContext,
        IGenreService genreService)
    {
        _dataContext = dataContext;
        _genreService = genreService;
    }

    public async Task<Guid> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = await _dataContext.Genres
                        .FirstOrDefaultAsync(x => x.IsnGenre == request.Genre.IsnGenre, cancellationToken)
                    ?? throw new BusinessLogicException(
                        $"Жанр с идентификатором \"{request.Genre.IsnGenre}\" не существует");

        genre.Name = request.Genre.Name;

        await _genreService.CreateOrUpdateGenreValidateAndThrowAsync(
            _dataContext, genre, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return genre.IsnGenre;
    }
}