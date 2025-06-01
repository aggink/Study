using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Library;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Library;

namespace Study.Lab3.Logic.Services.Library;

public sealed class AuthorService : IAuthorService
{
    public async Task CreateOrUpdateAuthorValidateAndThrowAsync(DataContext dataContext, Authors author, CancellationToken cancellationToken = default)
    {
        if (await dataContext.Authors.AnyAsync(x => x.IsnAuthor != author.IsnAuthor
        && x.SurName == author.SurName && x.Name == author.Name && x.PatronymicName == author.PatronymicName && x.Sex == author.Sex, cancellationToken))
            throw new BusinessLogicException($"Автор с id \"{author.IsnAuthor}\" уже существует");
    }
}
