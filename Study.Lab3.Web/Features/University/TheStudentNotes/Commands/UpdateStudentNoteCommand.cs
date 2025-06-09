using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.TheStudentNotes.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.StudentNotes.Commands;

/// <summary>
/// Обновление заметки студента
/// </summary>
public sealed class UpdateStudentNoteCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные заметки
    /// </summary>
    [Required]
    [FromBody]
    public UpdateStudentNoteDto Note { get; init; }
}

public sealed class UpdateStudentNoteCommandHandler
    : IRequestHandler<UpdateStudentNoteCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IStudentNoteService _studentNoteService;

    public UpdateStudentNoteCommandHandler(
        DataContext dataContext,
        IStudentNoteService studentNoteService)
    {
        _dataContext = dataContext;
        _studentNoteService = studentNoteService;
    }

    public async Task<Guid> Handle(
        UpdateStudentNoteCommand request,
        CancellationToken cancellationToken)
    {
        var note = await _dataContext.StudentNotes
            .FirstOrDefaultAsync(x => x.IsnNote == request.Note.IsnNote, cancellationToken)
                ?? throw new BusinessLogicException(
                    $"Заметка с идентификатором \"{request.Note.IsnNote}\" не найдена");

        note.Text = request.Note.Text;

        await _studentNoteService.CreateOrUpdateNoteValidateAndThrowAsync(
            _dataContext, note, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return note.IsnNote;
    }
}