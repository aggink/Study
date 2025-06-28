using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopAuthor.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopAuthor.Queries;

public sealed record GetBookshopAuthorByIdQuery(int AuthorId)
        : IRequest<BookshopAuthorDto?>;
