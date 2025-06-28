using Study.Lab3.Storage.Models.Bookshop;

namespace Study.Lab3.Logic.Interfaces.Services.Bookshop;

public interface IBookshopGenreService
{
    Task<IEnumerable<BookshopGenre>> GetAllAsync(CancellationToken ct = default);
    Task<BookshopGenre?>            GetByIdAsync(int genreId, CancellationToken ct = default);
    Task<BookshopGenre>             CreateAsync (BookshopGenre entity, CancellationToken ct = default);
    Task<BookshopGenre?>            UpdateAsync (BookshopGenre entity, CancellationToken ct = default);
    Task<bool>                      DeleteAsync (int genreId,   CancellationToken ct = default);
}
