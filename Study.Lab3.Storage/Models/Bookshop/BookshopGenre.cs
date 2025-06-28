using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Study.Lab3.Storage.Models.Bookshop;

public sealed class BookshopGenre
{
    [Key]
    public int GenreId { get; set; }

    public string Name { get; set; }

    public ICollection<BookshopBook> Books { get; set; } = new List<BookshopBook>();
}
