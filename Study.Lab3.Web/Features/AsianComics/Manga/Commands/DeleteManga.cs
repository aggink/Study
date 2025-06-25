using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.AsianComics;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.AsianComics.Manga.Commands;

public sealed class DeleteMangaCommand : IRequest
{
    [Required]
    [FromQuery]
    public Guid IsnBook { get; init; }
}

public sealed class DeleteMangaCommandHandler : IRequestHandler<DeleteMangaCommand>
{
    private readonly DataContext _dataContext;
    private readonly IMangaService _mangaService;

    public DeleteMangaCommandHandler(DataContext dataContext, IMangaService mangaService)
    {
        _dataContext = dataContext;
        _mangaService = mangaService;
    }

    public async Task Handle(DeleteMangaCommand request, CancellationToken cancellationToken)
    {
        var manga = await _dataContext.Manga.FirstOrDefaultAsync(x => x.IsnBook == request.IsnBook, cancellationToken)
             ?? throw new BusinessLogicException($"Манги с идентификатором \"{request.IsnBook}\" не существует");

        _dataContext.Manga.Remove(manga);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return;
    }
}
