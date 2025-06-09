using MediatR;
using Study.Lab3.Storage.Database;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Web.Features.University.TheStudentNotes.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheStudentNotes.Queries;

/// <summary>
/// Получить заметку студента с деталями
/// </summary>
public sealed class GetStudentNoteByStudentIdQuery : IRequest<StudentNoteWithDetailsDto>
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    [Required]
    public Guid StudentId { get; init; }
}

public sealed class GetStudentNoteByStudentIdQueryHandler
    : IRequestHandler<GetStudentNoteByStudentIdQuery, StudentNoteWithDetailsDto>
{
    private readonly DataContext _dataContext;

    public GetStudentNoteByStudentIdQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<StudentNoteWithDetailsDto> Handle(
        GetStudentNoteByStudentIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _dataContext.StudentNotes
            .AsNoTracking()
            .Where(x => x.IsnStudent == request.StudentId)
            .Select(note => new StudentNoteWithDetailsDto
            {
                IsnNote = note.IsnNote,
                IsnStudent = note.IsnStudent,
                Text = note.Text
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
}