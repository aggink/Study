using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Study.Lab3.Storage.Models.Bookshop;

public class BookshopAuthor
{
    [Key]
    public int AuthorId { get; set; }

    [MaxLength(150)]
    public string Name { get; set; }

    public int? BirthYear { get; set; }

    // Навигация (если нужна)
    public ICollection<BookshopBook>? Books { get; set; }
}
