using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopAuthor.DtoModels;

namespace Study.Lab3.Web.Features.Bookshop.BookshopAuthor.Commands;

public sealed class UpdateBookshopAuthorCommand : IRequest<BookshopAuthorDto>
{
    public int      AuthorId  { get; set; }          
    public string  Name      { get; set; }
    public int?     BirthYear { get; set; }
}
