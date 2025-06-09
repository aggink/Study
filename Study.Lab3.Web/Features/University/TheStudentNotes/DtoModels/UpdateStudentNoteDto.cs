using System;

namespace Study.Lab3.Web.Features.University.TheStudentNotes.DtoModels;

/// <summary>
/// DTO для обновления заметки студента
/// </summary>
public sealed class UpdateStudentNoteDto
{
    /// <summary>
    /// Идентификатор заметки
    /// </summary>
    public Guid IsnNote { get; init; }

    /// <summary>
    /// Новый текст заметки
    /// </summary>
    public string Text { get; init; }
}