using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Library;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Library;

namespace Study.Lab3.Logic.Services.Library;

public class BookService : IBookService
{
    public async Task CreateOrUpdateBookValidateAndThrowAsync(DataContext dataContext, Books book, CancellationToken cancellationToken = default)
    {
        if (await dataContext.Books.AnyAsync(x => x.IsnBook != book.IsnBook && x.Title == book.Title && x.PublicationYear == book.PublicationYear, cancellationToken))
            throw new BusinessLogicException($"Книга с такими параметрами уже создана");
    }
}
