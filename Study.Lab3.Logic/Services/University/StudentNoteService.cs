using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Logic.Interfaces.Services.University;
using CoreLib.Common.Extensions;

namespace Study.Lab3.Logic.Services.University;
public class StudentNoteService : IStudentNoteService
{
    public async Task CreateOrUpdateNoteValidateAndThrowAsync(
        DataContext dataContext,
        StudentNote note,
        CancellationToken cancellationToken)
    {
        if (!await dataContext.Students.AnyAsync(s => s.IsnStudent == note.IsnStudent, cancellationToken))
            throw new BusinessLogicException($"Student with ID {note.IsnStudent} not found");

        if (string.IsNullOrWhiteSpace(note.Text))
            throw new BusinessLogicException("Note text cannot be empty");

        if (note.Text.Length > 500)
            throw new BusinessLogicException("Note text exceeds maximum length of 500 characters");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        StudentNote note,
        CancellationToken cancellationToken)
    {
        if (!await dataContext.StudentNotes.AnyAsync(n => n.IsnNote == note.IsnNote, cancellationToken))
            throw new BusinessLogicException("Note not found");
    }
}