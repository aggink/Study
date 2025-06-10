using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheStudentNotes.DtoModels;

/// <summary>
/// DTO для создания заметки студента
/// </summary>
public sealed class CreateStudentNoteDto
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    [Required]
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// Текст заметки
    /// </summary>
    /// 
    [Required]
    public string Text { get; init; }
}