using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Cinema;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Cinema;
using Study.Lab3.Web.Features.Cinema.Genres.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Genres.Commands;

/// <summary>
/// Создание жанра
/// </summary>
public sealed class CreateGenreCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные жанра
    /// </summary>
    [Required]
    [FromBody]
    public CreateGenreDto Genre { get; init; }
}

public sealed class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IGenreService _genreService;

    public CreateGenreCommandHandler(
        DataContext dataContext,
        IGenreService genreService)
    {
        _dataContext = dataContext;
        _genreService = genreService;
    }

    public async Task<Guid> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = new Genre
        {
            IsnGenre = Guid.NewGuid(),
            Name = request.Genre.Name
        };

        await _genreService.CreateOrUpdateGenreValidateAndThrowAsync(
            _dataContext, genre, cancellationToken);

        await _dataContext.Genres.AddAsync(genre, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return genre.IsnGenre;
    }
}