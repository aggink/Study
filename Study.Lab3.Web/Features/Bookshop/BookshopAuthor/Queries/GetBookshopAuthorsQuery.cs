using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopAuthor.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopAuthor.Queries;

public class GetBookshopAuthorsQuery : IRequest<IEnumerable<BookshopAuthorDto>>;
