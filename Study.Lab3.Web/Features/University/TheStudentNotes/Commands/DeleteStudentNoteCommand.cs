using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheStudentNotes.Commands;

/// <summary>
/// Удаление заметки студента
/// </summary>
public sealed class DeleteStudentNoteCommand : IRequest
{
    /// <summary>
    /// Идентификатор заметки
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnNote { get; init; }
}

public sealed class DeleteStudentNoteCommandHandler
    : IRequestHandler<DeleteStudentNoteCommand>
{
    private readonly DataContext _dataContext;
    private readonly IStudentNoteService _studentNoteService;

    public DeleteStudentNoteCommandHandler(
        DataContext dataContext,
        IStudentNoteService studentNoteService)
    {
        _dataContext = dataContext;
        _studentNoteService = studentNoteService;
    }

    public async Task Handle(
        DeleteStudentNoteCommand request,
        CancellationToken cancellationToken)
    {
        var note = await _dataContext.StudentNotes
            .FirstOrDefaultAsync(x => x.IsnNote == request.IsnNote, cancellationToken)
                ?? throw new BusinessLogicException(
                    $"Заметка с идентификатором \"{request.IsnNote}\" не найдена");

        await _studentNoteService.CanDeleteAndThrowAsync(
            _dataContext, note, cancellationToken);

        _dataContext.StudentNotes.Remove(note);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}