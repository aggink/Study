using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Bookshop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Bookshop;

namespace Study.Lab3.Logic.Services.Bookshop;

/// <summary>CRUD-сервис Жанров книжного магазина.</summary>
public sealed class BookshopGenreService : IBookshopGenreService
{
    private readonly DataContext _db;
    public BookshopGenreService(DataContext db) => _db = db;

    public async Task<IEnumerable<BookshopGenre>> GetAllAsync(CancellationToken ct = default) =>
        await _db.BookshopGenres.AsNoTracking().ToListAsync(ct);

    public async Task<BookshopGenre?> GetByIdAsync(int genreId, CancellationToken ct = default) =>
        await _db.BookshopGenres.AsNoTracking()
                                .FirstOrDefaultAsync(g => g.GenreId == genreId, ct);

    public async Task<BookshopGenre> CreateAsync(BookshopGenre entity, CancellationToken ct = default)
    {
        _db.BookshopGenres.Add(entity);
        await _db.SaveChangesAsync(ct);
        return entity;
    }

    public async Task<BookshopGenre?> UpdateAsync(BookshopGenre entity, CancellationToken ct = default)
    {
        _db.BookshopGenres.Update(entity);
        await _db.SaveChangesAsync(ct);
        return entity;
    }

    public async Task<bool> DeleteAsync(int genreId, CancellationToken ct = default)
    {
        var existing = await _db.BookshopGenres.FindAsync(new object[] { genreId }, ct);
        if (existing is null) return false;

        _db.BookshopGenres.Remove(existing);
        await _db.SaveChangesAsync(ct);
        return true;
    }
}
