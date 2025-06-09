using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.TheStudentNotes.DtoModels;
using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Web.Features.University.TheStudentNotes.Commands;

/// <summary>
/// Создание заметки студента
/// </summary>
public sealed class CreateStudentNoteCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные заметки
    /// </summary>
    [Required]
    [FromBody]
    public CreateStudentNoteDto Note { get; init; }
}

public sealed class CreateStudentNoteCommandHandler : IRequestHandler<CreateStudentNoteCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IStudentNoteService _studentNoteService;

    public CreateStudentNoteCommandHandler(
        DataContext dataContext,
        IStudentNoteService studentNoteService)
    {
        _dataContext = dataContext;
        _studentNoteService = studentNoteService;
    }

    public async Task<Guid> Handle(CreateStudentNoteCommand request, CancellationToken cancellationToken)
    {
        var note = new StudentNote
        {
            IsnNote = Guid.NewGuid(),
            IsnStudent = request.Note.IsnStudent,
            Text = request.Note.Text
        };

        await _studentNoteService.CreateOrUpdateNoteValidateAndThrowAsync(
            _dataContext, note, cancellationToken);

        // Удаляем предыдущую заметку студента (если есть)
        var existingNote = await _dataContext.StudentNotes
            .FirstOrDefaultAsync(n => n.IsnStudent == note.IsnStudent, cancellationToken);

        if (existingNote != null)
        {
            _dataContext.StudentNotes.Remove(existingNote);
        }

        await _dataContext.StudentNotes.AddAsync(note, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return note.IsnNote;
    }
}