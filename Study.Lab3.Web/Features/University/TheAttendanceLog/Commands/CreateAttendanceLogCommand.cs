using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Web.Features.University.TheAttendanceLog.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheAttendanceLog.Commands;

/// <summary>
/// Создание посещаемости
/// </summary>
public sealed class CreateAttendanceLogCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные посещаемости
    /// </summary>
    [Required]
    [FromBody]
    public CreateAttendanceLogDto AttendanceLog { get; init; }
}

public sealed class CreateAttendanceLogCommandHandler : IRequestHandler<CreateAttendanceLogCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IAttendanceLogService _attendanceLogService;

    public CreateAttendanceLogCommandHandler(
        DataContext dataContext,
        IAttendanceLogService attendanceLogService)
    {
        _dataContext = dataContext;
        _attendanceLogService = attendanceLogService;
    }

    public async Task<Guid> Handle(CreateAttendanceLogCommand request, CancellationToken cancellationToken)
    {
        var attendanceLog = new AttendanceLog
        {
            IsnAttendanceLog = Guid.NewGuid(),
            IsnStudent = request.AttendanceLog.IsnStudent,
            IsnSubject = request.AttendanceLog.IsnSubject,
            SubjectDate = request.AttendanceLog.SubjectDate,
            IsPresent = request.AttendanceLog.IsPresent
        };

        await _attendanceLogService.CreateOrUpdateAttendanceLogValidateAndThrowAsync(
            _dataContext, attendanceLog, cancellationToken);

        await _dataContext.TheAttendanceLog.AddAsync(attendanceLog, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return attendanceLog.IsnAttendanceLog;
    }
}
