using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopAuthor.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopAuthor.Commands;

public class CreateBookshopAuthorCommand : IRequest<BookshopAuthorDto>
{
    public string Name { get; set; } = string.Empty;
    public int BirthYear { get; set; }
}
