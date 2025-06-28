using MediatR;

namespace Study.Lab3.Web.Features.Bookshop.BookshopBooks.Commands;

/// <summary>
/// Команда на удаление книги
/// </summary>
/// <param name="BookId">идентификатор книги</param>
public sealed record DeleteBookshopBookCommand(int BookId)
    : IRequest<bool>;
