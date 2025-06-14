using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.TheAttendanceLog.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheAttendanceLog.Commands;

/// <summary>
/// Редактирование посещения
/// </summary>
public sealed class UpdateAttendanceLogCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные посещаемости
    /// </summary>
    [Required]
    [FromBody]
    public UpdateAttendanceLogDto AttendanceLog { get; init; }
}

public sealed class UpdateAttendanceLogCommandHandler : IRequestHandler<UpdateAttendanceLogCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IAttendanceLogService _attendanceLogService;

    public UpdateAttendanceLogCommandHandler(
        DataContext dataContext,
        IAttendanceLogService attendanceLogService)
    {
        _dataContext = dataContext;
        _attendanceLogService = attendanceLogService;
    }

    public async Task<Guid> Handle(UpdateAttendanceLogCommand request, CancellationToken cancellationToken)
    {
        var attendanceLog = await _dataContext.TheAttendanceLog
            .Include(x => x.Subject)
            .FirstOrDefaultAsync(x => x.IsnAttendanceLog == request.AttendanceLog.IsnAttendanceLog, cancellationToken)
                ?? throw new BusinessLogicException($"Посещение с идентификатором \"{request.AttendanceLog.IsnAttendanceLog}\" не существует");

        attendanceLog.IsPresent = request.AttendanceLog.IsPresent;
        attendanceLog.SubjectDate = request.AttendanceLog.SubjectDate;

        await _attendanceLogService.CreateOrUpdateAttendanceLogValidateAndThrowAsync(
            _dataContext, attendanceLog, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return attendanceLog.IsnAttendanceLog;
    }
}