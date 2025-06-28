using Study.Lab3.Storage.Models.Bookshop;
namespace Study.Lab3.Logic.Interfaces.Services.Bookshop;

public interface IBookshopAuthorService
{
    Task<IEnumerable<BookshopAuthor>> GetAllAsync(CancellationToken ct = default);
    Task<BookshopAuthor?>            GetByIdAsync(int authorId, CancellationToken ct = default);
    Task<BookshopAuthor>             CreateAsync (BookshopAuthor entity, CancellationToken ct = default);
    Task<BookshopAuthor?>            UpdateAsync (BookshopAuthor entity, CancellationToken ct = default);
    Task<bool>                       DeleteAsync (int authorId,   CancellationToken ct = default);
}
