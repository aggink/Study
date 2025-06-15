using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CarService.ServiceRecord.DtoModels;

namespace Study.Lab3.Web.Features.CarService.ServiceRecord.Queries;

public sealed class GetServiceRecordByIsnQuery : IRequest<ServiceRecordDto>
{
    /// <summary>
    /// Идентификатор записи обслуживания
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnServiceRecord { get; init; }
}
 
public sealed class GetServiceRecordByIsnQueryHandler : IRequestHandler<GetServiceRecordByIsnQuery, ServiceRecordDto>
{
    private readonly DataContext _dataContext;
 
    public GetServiceRecordByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
 
    public async Task<ServiceRecordDto> Handle(GetServiceRecordByIsnQuery request, CancellationToken cancellationToken)
    {
        var serviceRecord = await _dataContext.ServiceRecords
                                .AsNoTracking()
                                .FirstOrDefaultAsync(x => x.IsnServiceRecord == request.IsnServiceRecord, cancellationToken)
                            ?? throw new BusinessLogicException($"Запись обслуживания с идентификатором \"{request.IsnServiceRecord}\" не существует");
 
        return new ServiceRecordDto
        {
            IsnServiceRecord = serviceRecord.IsnServiceRecord,
            CarLicensePlate = serviceRecord.CarLicensePlate,
            ServiceDate = serviceRecord.ServiceDate,
            ServiceType = serviceRecord.ServiceType,
            Description = serviceRecord.Description,
            MechanicName = serviceRecord.MechanicName,
            Cost = serviceRecord.Cost,
            IsCompleted = serviceRecord.IsCompleted
        };
    }
}