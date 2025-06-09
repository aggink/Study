using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.TheAttendanceLog.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheAttendanceLog.Queries;

/// <summary>
/// Получить факт посещения по идентификатору
/// </summary>
public sealed class GetAttendanceLogByIsnQuery : IRequest<AttendanceLogDto>
{
    /// <summary>
    /// Идентификатор факта посещения
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnAttendanceLog { get; init; }
}

public sealed class GetAttendanceLogByIsnQueryHandler : IRequestHandler<GetAttendanceLogByIsnQuery, AttendanceLogDto>
{
    private readonly DataContext _dataContext;

    public GetAttendanceLogByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<AttendanceLogDto> Handle(GetAttendanceLogByIsnQuery request, CancellationToken cancellationToken)
    {
        var attendanceLog = await _dataContext.TheAttendanceLog
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnAttendanceLog == request.IsnAttendanceLog, cancellationToken)
                ?? throw new BusinessLogicException($"Факт посещения с идентификатором \"{request.IsnAttendanceLog}\" не существует");

        return new AttendanceLogDto
        {
            IsnAttendanceLog = attendanceLog.IsnAttendanceLog,
            IsnStudent = attendanceLog.IsnStudent,
            IsnSubject = attendanceLog.IsnSubject,
            SubjectDate = attendanceLog.SubjectDate,
            IsPresent = attendanceLog.IsPresent
        };
    }
}