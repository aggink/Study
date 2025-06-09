namespace Study.Lab3.Web.Features.University.TheStudentNotes.DtoModels;

/// <summary>
/// DTO для создания заметки студента
/// </summary>
public sealed class CreateStudentNoteDto
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// Текст заметки
    /// </summary>
    public string Text { get; init; }
}