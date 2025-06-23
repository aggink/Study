using Study.Lab3.Logic.Interfaces.Services.Bookshop;
using Study.Lab3.Storage.Models.Bookshop;

namespace Study.Lab3.Logic.Services.Bookshop;

public class BookshopGenreService : IBookshopGenreService
{
    public IEnumerable<BookshopGenre> GetAll()
    {
        return new[]
        {
            new BookshopGenre { Id = 1, Name = "Fiction" },
            new BookshopGenre { Id = 2, Name = "Non-fiction" }
        };
    }
}
