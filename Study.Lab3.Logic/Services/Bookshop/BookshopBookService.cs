using Study.Lab3.Storage.Models.Bookshop;
using Study.Lab3.Logic.Interfaces.Services.Bookshop;

namespace Study.Lab3.Logic.Services.Bookshop;

public class BookshopBookService : IBookshopBookService
{
    public IEnumerable<BookshopBook> GetAll()
    {
        return new[]
        {
            new BookshopBook { Id = 1, Title = "Book 1", Pages = 100 },
            new BookshopBook { Id = 2, Title = "Book 2", Pages = 200 },
        };
    }
}
