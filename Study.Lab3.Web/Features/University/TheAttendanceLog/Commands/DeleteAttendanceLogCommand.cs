using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheAttendanceLog.Commands;


/// <summary>
/// �������� ���������
/// </summary>
public sealed class DeleteAttendanceLogCommand : IRequest
{
    /// <summary>
    /// ������������� ������������
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnAttendanceLog { get; init; }
}

public sealed class DeleteAttendanceLogCommandHandler : IRequestHandler<DeleteAttendanceLogCommand>
{
    private readonly DataContext _dataContext;
    private readonly IAttendanceLogService _attendanceLogService;

    public DeleteAttendanceLogCommandHandler(
        DataContext dataContext,
        IAttendanceLogService attendanceLogService)
    {
        _dataContext = dataContext;
        _attendanceLogService = attendanceLogService;
    }

    public async Task Handle(DeleteAttendanceLogCommand request, CancellationToken cancellationToken)
    {
        var attendanceLog = await _dataContext.TheAttendanceLog
            .Include(x => x.Subject)
            .FirstOrDefaultAsync(x => x.IsnAttendanceLog == request.IsnAttendanceLog, cancellationToken)
                ?? throw new BusinessLogicException($"��������� � ��������������� \"{request.IsnAttendanceLog}\" �� ����������");


        _dataContext.TheAttendanceLog.Remove(attendanceLog);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}