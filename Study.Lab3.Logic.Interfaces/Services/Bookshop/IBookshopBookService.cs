using Study.Lab3.Storage.Models.Bookshop;

namespace Study.Lab3.Logic.Interfaces.Services.Bookshop;

 public interface IBookshopBookService
 {
     Task<IEnumerable<BookshopBook>> GetAllAsync(CancellationToken ct = default);
     Task<BookshopBook?>             GetByIdAsync(int bookId, CancellationToken ct = default);
     Task<BookshopBook>              CreateAsync(BookshopBook entity,  CancellationToken ct = default);
     Task<BookshopBook?>             UpdateAsync(BookshopBook entity,  CancellationToken ct = default);
     Task<bool>                      DeleteAsync(int bookId,          CancellationToken ct = default);

    /// <summary>Есть ли у указанного автора хотя бы одна книга.</summary>
    Task<bool> ExistsByAuthorAsync(int authorId, CancellationToken ct = default);

    /// <summary>Есть ли в указанном жанре хотя бы одна книга (пригодится для Genre).</summary>
    Task<bool> ExistsByGenreAsync (int genreId,  CancellationToken ct = default);
 }
