using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.AsianComics;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.AsianComics.Manga.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.AsianComics.Manga.Commands;

public sealed class CreateMangaCommand : IRequest<Guid>
{
    [FromBody]
    [Required]
    public CreateMangaDto Manga { get; init; }
}

public sealed class CreateMangaCommandHandler : IRequestHandler<CreateMangaCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IMangaService _mangaService;

    public CreateMangaCommandHandler(
        DataContext dataContext, IMangaService mangaService)
    {
        _dataContext = dataContext;
        _mangaService = mangaService;
    }

    public async Task<Guid> Handle(CreateMangaCommand request, CancellationToken cancellationToken)
    {
        var manga = new Storage.Models.AsianComics.Manga
        {
            IsnBook = Guid.NewGuid(),
            Title = request.Manga.Title,
            PublicationYear = request.Manga.PublicationYear,
        };

        await _mangaService.CreateOrUpdateMangaValidateAndThrowAsync(_dataContext, manga, cancellationToken);

        await _dataContext.Manga.AddAsync(manga, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return manga.IsnBook;
    }
}

