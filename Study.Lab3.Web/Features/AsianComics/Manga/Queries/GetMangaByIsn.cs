using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.AsianComics.Manga.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.AsianComics.Manga.Queries;

public sealed class GetMangaByIsnQuery : IRequest<MangaDto>
{
    [Required]
    [FromQuery]
    public Guid IsnBook { get; init; }
}

public sealed class GetMangaByIsnQueryHandler : IRequestHandler<GetMangaByIsnQuery, MangaDto>
{
    private readonly DataContext _dataContext;

    public GetMangaByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MangaDto> Handle(GetMangaByIsnQuery request, CancellationToken cancellationToken)
    {
        var manga = await _dataContext.Manga
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnBook == request.IsnBook, cancellationToken)
                ?? throw new BusinessLogicException($"Манги с идентификатором \"{request.IsnBook}\" не существует");

        return new MangaDto
        {
            IsnBook = manga.IsnBook,
            Title = manga.Title,
            PublicationYear = manga.PublicationYear,
        };
    }
}