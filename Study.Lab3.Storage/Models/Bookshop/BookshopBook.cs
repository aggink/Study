using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Storage.Models.Bookshop;

public sealed class BookshopBook
{
    [Key]
    public int BookId { get; set; }

    public string Title { get; set; }
    public int?    Pages { get; set; }

    // FK + нав.-свойства
    public int    AuthorId { get; set; }
    public BookshopAuthor? Author { get; set; }

    public int    GenreId  { get; set; }
    public BookshopGenre?  Genre  { get; set; }
}
