using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CarService;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CarService.ServiceRecord.DtoModels;

namespace Study.Lab3.Web.Features.CarService.ServiceRecord.Commands;

public sealed class UpdateServiceRecordCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные записи обслуживания
    /// </summary>
    [Required]
    [FromBody]
    public UpdateServiceRecordDto ServiceRecord { get; init; }
}
 
public sealed class UpdateServiceRecordCommandHandler : IRequestHandler<UpdateServiceRecordCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IServiceRecordService _serviceRecordService;
 
    public UpdateServiceRecordCommandHandler(
        DataContext dataContext,
        IServiceRecordService serviceRecordService)
    {
        _dataContext = dataContext;
        _serviceRecordService = serviceRecordService;
    }
 
    public async Task<Guid> Handle(UpdateServiceRecordCommand request, CancellationToken cancellationToken)
    {
        var serviceRecord = await _dataContext.ServiceRecords
                                .FirstOrDefaultAsync(x => x.IsnServiceRecord == request.ServiceRecord.IsnServiceRecord, cancellationToken)
                            ?? throw new BusinessLogicException($"Запись обслуживания с идентификатором \"{request.ServiceRecord.IsnServiceRecord}\" не существует");
 
        serviceRecord.CarLicensePlate = request.ServiceRecord.CarLicensePlate;
        serviceRecord.ServiceDate = request.ServiceRecord.ServiceDate;
        serviceRecord.ServiceType = request.ServiceRecord.ServiceType;
        serviceRecord.Description = request.ServiceRecord.Description;
        serviceRecord.MechanicName = request.ServiceRecord.MechanicName;
        serviceRecord.Cost = request.ServiceRecord.Cost;
        serviceRecord.IsCompleted = request.ServiceRecord.IsCompleted;
 
        await _serviceRecordService.CreateOrUpdateServiceRecordValidateAndThrowAsync(
            _dataContext, serviceRecord, cancellationToken);
 
        await _dataContext.SaveChangesAsync(cancellationToken);
        return serviceRecord.IsnServiceRecord;
    }
}