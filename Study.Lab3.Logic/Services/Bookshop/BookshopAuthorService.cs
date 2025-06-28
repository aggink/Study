using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Bookshop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Bookshop;

namespace Study.Lab3.Logic.Services.Bookshop;

/// <summary>CRUD-сервис Авторов книжного магазина.</summary>
public sealed class BookshopAuthorService : IBookshopAuthorService
{
    private readonly DataContext _db;
    public BookshopAuthorService(DataContext db) => _db = db;

    public async Task<IEnumerable<BookshopAuthor>> GetAllAsync(CancellationToken ct = default) =>
        await _db.BookshopAuthors.AsNoTracking().ToListAsync(ct);

    public async Task<BookshopAuthor?> GetByIdAsync(int authorId, CancellationToken ct = default) =>
        await _db.BookshopAuthors.AsNoTracking()
                                 .FirstOrDefaultAsync(a => a.AuthorId == authorId, ct);

    public async Task<BookshopAuthor> CreateAsync(BookshopAuthor entity, CancellationToken ct = default)
    {
        _db.BookshopAuthors.Add(entity);
        await _db.SaveChangesAsync(ct);
        return entity;
    }

    public async Task<BookshopAuthor?> UpdateAsync(BookshopAuthor entity, CancellationToken ct = default)
    {
        _db.BookshopAuthors.Update(entity);
        await _db.SaveChangesAsync(ct);
        return entity;
    }

    public async Task<bool> DeleteAsync(int authorId, CancellationToken ct = default)
    {
        var existing = await _db.BookshopAuthors.FindAsync(new object[] { authorId }, ct);
        if (existing is null) return false;

        _db.BookshopAuthors.Remove(existing);
        await _db.SaveChangesAsync(ct);
        return true;
    }
}
