using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CarService;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.CarService.ServiceRecord.Commands;

public sealed class DeleteServiceRecordCommand : IRequest
{
    /// <summary>
    /// Идентификатор записи обслуживания
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnServiceRecord { get; init; }
}
 
public sealed class DeleteServiceRecordCommandHandler : IRequestHandler<DeleteServiceRecordCommand>
{
    private readonly DataContext _dataContext;
    private readonly IServiceRecordService _serviceRecordService;
 
    public DeleteServiceRecordCommandHandler(
        DataContext dataContext,
        IServiceRecordService serviceRecordService)
    {
        _dataContext = dataContext;
        _serviceRecordService = serviceRecordService;
    }
 
    public async Task Handle(DeleteServiceRecordCommand request, CancellationToken cancellationToken)
    {
        var serviceRecord = await _dataContext.ServiceRecords
                                .FirstOrDefaultAsync(x => x.IsnServiceRecord == request.IsnServiceRecord, cancellationToken)
                            ?? throw new BusinessLogicException($"Запись обслуживания с идентификатором \"{request.IsnServiceRecord}\" не существует");
 
        await _serviceRecordService.CanDeleteAndThrowAsync(
            _dataContext, serviceRecord, cancellationToken);
 
        _dataContext.ServiceRecords.Remove(serviceRecord);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}