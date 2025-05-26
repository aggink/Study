using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Library.Books.DtoModels;

namespace Study.Lab3.Web.Features.Library.Books.Queries;

/// <summary>
/// Получение списка книг
/// </summary>
public sealed class GetListBooksQuery : IRequest<BookItemDto[]>
{

}

public sealed class GetListBooksQueryHandler : IRequestHandler<GetListBooksQuery, BookItemDto[]>
{
    private readonly DataContext _dataContext;

    public GetListBooksQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<BookItemDto[]> Handle(GetListBooksQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Books
            .AsNoTracking()
            .Select(x => new BookItemDto
            {
                IsnBook = x.IsnBook,
                Title = x.Title,
                PublicationYear = x.PublicationYear,
                Genre = x.Genre,
            })
            .OrderBy(x => x.Title)
            .ToArrayAsync(cancellationToken);
    }
}