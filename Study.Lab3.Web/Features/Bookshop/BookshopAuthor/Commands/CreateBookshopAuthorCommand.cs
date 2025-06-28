using MediatR;
using Study.Lab3.Web.Features.Bookshop.BookshopAuthor.DtoModels;

public class CreateBookshopAuthorCommand : IRequest<BookshopAuthorDto>
{
    public string Name      { get; set; }
    public int?    BirthYear { get; set; }
}
