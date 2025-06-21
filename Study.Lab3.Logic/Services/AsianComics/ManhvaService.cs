using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.AsianComics;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.AsianComics;

namespace Study.Lab3.Logic.Services.AsianComics;

public sealed class ManhvaService : IManhvaService
{
    public async Task CreateOrUpdateManhvaValidateAndThrowAsync(DataContext dataContext, Manhva manhva, CancellationToken cancellationToken = default)
    {
        if (await dataContext.Manhva.AnyAsync(x => x.IsnBook != manhva.IsnBook && x.Title == manhva.Title && x.PublicationYear == manhva.PublicationYear, cancellationToken))
            throw new BusinessLogicException($"Манхва с такими параметрами уже создана");
    }
}
