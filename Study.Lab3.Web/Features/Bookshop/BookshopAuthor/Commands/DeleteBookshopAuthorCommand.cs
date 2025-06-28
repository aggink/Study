using MediatR;

namespace Study.Lab3.Web.Features.Bookshop.BookshopAuthor.Commands;

public record DeleteBookshopAuthorCommand(int AuthorId) : IRequest<bool>;
