using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.University;
using Study.Lab3.Storage.Models.University;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Library;

/// <summary>
/// Автор
/// </summary>
public class Authors
{
    /// <summary>
    /// Идентификатор автора
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnAuthor { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    [Required, MaxLength(ModelConstants.Author.SurName)]
    public string SurName { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required, MaxLength(ModelConstants.Author.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    [Required, MaxLength(ModelConstants.Author.PatronymicName)]
    public string PatronymicName { get; set; }

    /// <summary>
    /// Пол
    /// </summary>
    public SexType Sex { get; set; }

    /// <summary>
    /// Идентификатор преподавателя
    /// </summary>
    [ForeignKey(nameof(Teacher))]
    public Guid? IsnTeacher { get; set; }

    /// <summary>
    /// Преподаватель
    /// </summary>
    public virtual Teacher Teacher { get; set; }

    /// <summary>
    /// Связь с таблицей Авторы - Книги
    /// </summary>
    [InverseProperty(nameof(AuthorBooks.Author))]
    public virtual ICollection<AuthorBooks> AuthorBook { get; set; }
}
