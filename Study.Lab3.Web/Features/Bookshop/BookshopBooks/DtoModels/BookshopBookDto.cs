namespace Study.Lab3.Web.Features.Bookshop.BookshopBooks.DtoModels;

public sealed record BookshopBookDto(int   BookId, string Title, int?   Pages, int?   AuthorId, int?   GenreId);
