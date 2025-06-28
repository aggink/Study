using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopBooks.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopBooks.Queries;

public sealed record GetBookshopBookByIdQuery(int BookId)
        : IRequest<BookshopBookDto?>;
