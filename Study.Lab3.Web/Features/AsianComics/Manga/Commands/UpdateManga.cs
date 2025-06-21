using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.AsianComics;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.AsianComics.Manga.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.AsianComics.Manga.Commands;

public sealed class UpdateMangaCommand : IRequest<Guid>
{
    [Required]
    [FromBody]
    public UpdateMangaDto Manga { get; init; }
}

public sealed class UpdateMangaCommandHandler : IRequestHandler<UpdateMangaCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IMangaService _mangaService;

    public UpdateMangaCommandHandler(DataContext dataContext, IMangaService mangaService)
    {
        _dataContext = dataContext;
        _mangaService = mangaService;
    }

    public async Task<Guid> Handle(UpdateMangaCommand request, CancellationToken cancellationToken)
    {
        var manga = await _dataContext.Manga.FirstOrDefaultAsync(x => x.IsnBook == request.Manga.IsnBook, cancellationToken)
             ?? throw new BusinessLogicException($" ниги с идентификатором \"{request.Manga.IsnBook}\" не существует");

        manga.Title = request.Manga.Title;
        manga.PublicationYear = request.Manga.PublicationYear;

        await _mangaService.CreateOrUpdateMangaValidateAndThrowAsync(_dataContext, manga, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return manga.IsnBook;
    }
}