using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Library;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Library;

namespace Study.Lab3.Logic.Services.Library;

public sealed class AuthorBookService : IAuthorBookService
{
    public async Task CreateAuthorBookValidateAndThrowAsync(DataContext dataContext, AuthorBooks authorBook, CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Authors.AnyAsync(x => x.IsnAuthor == authorBook.IsnAuthor, cancellationToken))
        {
            throw new BusinessLogicException($"Автора с идентификатором \"{authorBook.IsnAuthor}\" не существует");
        }

        if (!await dataContext.Books.AnyAsync(x => x.IsnBook == authorBook.IsnBook, cancellationToken))
        {
            throw new BusinessLogicException($"Книги с идентификатором \"{authorBook.IsnBook}\" не существует");
        }

        if (await dataContext.AuthorBooks.AnyAsync(x =>
            x.IsnBook == authorBook.IsnBook &&
            x.IsnAuthor == authorBook.IsnAuthor,
            cancellationToken))
        {
            throw new BusinessLogicException("Такая связь Автор-Книга уже существует");
        }
    }

    public async Task CanDeleteAuthorBook(DataContext dataContext, AuthorBooks authorBook, CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Authors.AnyAsync(x => x.IsnAuthor == authorBook.IsnAuthor, cancellationToken))
        {
            throw new BusinessLogicException($"Автора с идентификатором \"{authorBook.IsnAuthor}\" не существует");
        }

        if (!await dataContext.Books.AnyAsync(x => x.IsnBook == authorBook.IsnBook, cancellationToken))
        {
            throw new BusinessLogicException($"Книги с идентификатором \"{authorBook.IsnBook}\" не существует");
        }
    }
}
