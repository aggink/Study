using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopBooks.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopBooks.Queries;

public class GetBookshopBookByIdQuery : IRequest<BookshopBookDto>
{
    public int Id { get; set; }
}
