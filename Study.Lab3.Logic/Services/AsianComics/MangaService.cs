using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.AsianComics;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.AsianComics;

namespace Study.Lab3.Logic.Services.AsianComics;

public sealed class MangaService : IMangaService
{
    public async Task CreateOrUpdateMangaValidateAndThrowAsync(DataContext dataContext, Manga manga, CancellationToken cancellationToken = default)
    {
        if (await dataContext.Manga.AnyAsync(x => x.IsnBook != manga.IsnBook && x.Title == manga.Title && x.PublicationYear == manga.PublicationYear, cancellationToken))
            throw new BusinessLogicException($"Манга с такими параметрами уже создана");
    }
}
