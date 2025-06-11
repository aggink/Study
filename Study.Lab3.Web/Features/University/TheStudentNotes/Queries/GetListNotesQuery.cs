using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.TheStudentNotes.DtoModels;

namespace Study.Lab3.Web.Features.University.TheStudentNotes.Queries;

/// <summary>
/// Получение списка заметок студентов
/// </summary>
public sealed class GetListStudentNotesQuery : IRequest<StudentNoteDto[]>
{
}

public sealed class GetListStudentNotesQueryHandler
    : IRequestHandler<GetListStudentNotesQuery, StudentNoteDto[]>
{
    private readonly DataContext _dataContext;

    public GetListStudentNotesQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<StudentNoteDto[]> Handle(
        GetListStudentNotesQuery request,
        CancellationToken cancellationToken)
    {
        return await _dataContext.StudentNotes
            .AsNoTracking()
            .Select(x => new StudentNoteDto
            {
                IsnNote = x.IsnNote,
                IsnStudent = x.IsnStudent,
                Text = x.Text
            })
            .OrderByDescending(x => x.IsnStudent) // Или другой критерий сортировки
            .ToArrayAsync(cancellationToken);
    }
}