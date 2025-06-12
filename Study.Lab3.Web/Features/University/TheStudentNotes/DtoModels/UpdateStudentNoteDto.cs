using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheStudentNotes.DtoModels;

/// <summary>
/// DTO для обновления заметки студента
/// </summary>
public sealed class UpdateStudentNoteDto
{
    /// <summary>
    /// Идентификатор заметки
    /// </summary>
    [Required]
    public Guid IsnNote { get; init; }

    /// <summary>
    /// Новый текст заметки
    /// </summary>
    [Required]
    public string Text { get; init; }
}