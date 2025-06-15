using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.CarService;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CarService.ServiceRecord.DtoModels;

namespace Study.Lab3.Web.Features.CarService.ServiceRecord.Commands;

public sealed class CreateServiceRecordCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные записи обслуживания
    /// </summary>
    [Required]
    [FromBody]
    public CreateServiceRecordDto ServiceRecord { get; init; }
}
 
public sealed class CreateServiceRecordCommandHandler : IRequestHandler<CreateServiceRecordCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IServiceRecordService _serviceRecordService;
 
    public CreateServiceRecordCommandHandler(
        DataContext dataContext,
        IServiceRecordService serviceRecordService)
    {
        _dataContext = dataContext;
        _serviceRecordService = serviceRecordService;
    }
 
    public async Task<Guid> Handle(CreateServiceRecordCommand request, CancellationToken cancellationToken)
    {
        var serviceRecord = new Storage.Models.CarService.ServiceRecord
        {
            IsnServiceRecord = Guid.NewGuid(),
            CarLicensePlate = request.ServiceRecord.CarLicensePlate,
            ServiceDate = request.ServiceRecord.ServiceDate,
            ServiceType = request.ServiceRecord.ServiceType,
            Description = request.ServiceRecord.Description,
            MechanicName = request.ServiceRecord.MechanicName,
            Cost = request.ServiceRecord.Cost,
            IsCompleted = request.ServiceRecord.IsCompleted
        };
 
        await _serviceRecordService.CreateOrUpdateServiceRecordValidateAndThrowAsync(
            _dataContext, serviceRecord, cancellationToken);
 
        await _dataContext.ServiceRecords.AddAsync(serviceRecord, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
 
        return serviceRecord.IsnServiceRecord;
    }
}