using MediatR;

namespace Study.Lab3.Web.Features.Bookshop.BookshopGenre.Commands;

public record DeleteBookshopGenreCommand(int GenreId)  : IRequest<bool>;
