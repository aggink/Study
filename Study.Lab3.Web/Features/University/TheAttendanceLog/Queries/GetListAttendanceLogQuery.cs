using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.TheAttendanceLog.DtoModels;

namespace Study.Lab3.Web.Features.University.TheAttendanceLog.Queries;

/// <summary>
/// Получение списка посещений
/// </summary>
public sealed class GetListAttendanceLogQuery : IRequest<AttendanceLogDto[]>
{
}

public sealed class GetListAttendanceLogQueryHandler : IRequestHandler<GetListAttendanceLogQuery, AttendanceLogDto[]>
{
    private readonly DataContext _dataContext;

    public GetListAttendanceLogQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<AttendanceLogDto[]> Handle(GetListAttendanceLogQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.TheAttendanceLog
            .AsNoTracking()
            .Select(x => new AttendanceLogDto
            {
                IsnAttendanceLog = x.IsnAttendanceLog,
                IsnStudent = x.IsnStudent,
                IsnSubject = x.IsnSubject,
                SubjectDate = x.SubjectDate,
                IsPresent = x.IsPresent
            })
            .OrderByDescending(x => x.SubjectDate)
            .ToArrayAsync(cancellationToken);
    }
}