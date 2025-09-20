using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.AsianComics;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.AsianComics;

namespace Study.Lab3.Logic.Services.AsianComics;

public sealed class ManhuaService : IManhuaService
{
    public async Task CreateOrUpdateManhuaValidateAndThrowAsync(DataContext dataContext, Manhua manhua, CancellationToken cancellationToken = default)
    {
        if (await dataContext.Manhua.AnyAsync(x => x.IsnBook != manhua.IsnBook && x.Title == manhua.Title && x.PublicationYear == manhua.PublicationYear, cancellationToken))
            throw new BusinessLogicException($"Маньхуа с такими параметрами уже создана");
    }
}
