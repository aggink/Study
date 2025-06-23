using Study.Lab3.Storage.Models.Bookshop;

namespace Study.Lab3.Logic.Interfaces.Services.Bookshop;

public interface IBookshopGenreService
{
    IEnumerable<BookshopGenre> GetAll();
}
