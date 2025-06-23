using Study.Lab3.Logic.Interfaces.Services.Bookshop;

namespace Study.Lab3.Logic.Services.Bookshop;

public class BookshopAuthorService : IBookshopAuthorService
{
    public IEnumerable<object> GetAll()
    {
        return new[]
        {
            new { Id = 1, Name = "Author A", BirthYear = 1980 },
            new { Id = 2, Name = "Author B", BirthYear = 1990 },
        };
    }
}
