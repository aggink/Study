using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Bookshop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Bookshop;

namespace Study.Lab3.Logic.Services.Bookshop;

public sealed class BookshopBookService : IBookshopBookService
{
    private readonly DataContext _db;
    public BookshopBookService(DataContext db) => _db = db;

    public async Task<IEnumerable<BookshopBook>> GetAllAsync(CancellationToken ct = default) =>
        await _db.BookshopBooks.AsNoTracking().ToListAsync(ct);

    public async Task<BookshopBook?> GetByIdAsync(int bookId, CancellationToken ct = default) =>
        await _db.BookshopBooks.AsNoTracking()
                               .FirstOrDefaultAsync(b => b.BookId == bookId, ct);

    public async Task<BookshopBook> CreateAsync(BookshopBook entity, CancellationToken ct = default)
    {
        _db.BookshopBooks.Add(entity);
        await _db.SaveChangesAsync(ct);
        return entity;
    }

    public async Task<BookshopBook?> UpdateAsync(BookshopBook entity, CancellationToken ct = default)
    {
        _db.BookshopBooks.Update(entity);
        await _db.SaveChangesAsync(ct);
        return entity;
    }

    public async Task<bool> DeleteAsync(int bookId, CancellationToken ct = default)
    {
        var existing = await _db.BookshopBooks.FindAsync(new object[] { bookId }, ct);
        if (existing is null) return false;

        _db.BookshopBooks.Remove(existing);
        await _db.SaveChangesAsync(ct);
        return true;
    }

    /* --- проверки, нужны для Delete-хэндлеров --- */
    public Task<bool> ExistsByAuthorAsync(int authorId, CancellationToken ct = default) =>
        _db.BookshopBooks.AsNoTracking().AnyAsync(b => b.AuthorId == authorId, ct);

    public Task<bool> ExistsByGenreAsync(int genreId, CancellationToken ct = default)  =>
        _db.BookshopBooks.AsNoTracking().AnyAsync(b => b.GenreId  == genreId,  ct);
}
