using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CarService.ServiceRecord.DtoModels;

namespace Study.Lab3.Web.Features.CarService.ServiceRecord.Queries;

public sealed class GetListServiceRecordsQuery : IRequest<ServiceRecordDto[]>
{
}
 
public sealed class GetListServiceRecordsQueryHandler : IRequestHandler<GetListServiceRecordsQuery, ServiceRecordDto[]>
{
    private readonly DataContext _dataContext;
 
    public GetListServiceRecordsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
 
    public async Task<ServiceRecordDto[]> Handle(GetListServiceRecordsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.ServiceRecords
            .AsNoTracking()
            .Select(x => new ServiceRecordDto
            {
                IsnServiceRecord = x.IsnServiceRecord,
                CarLicensePlate = x.CarLicensePlate,
                ServiceDate = x.ServiceDate,
                ServiceType = x.ServiceType,
                Description = x.Description,
                MechanicName = x.MechanicName,
                Cost = x.Cost,
                IsCompleted = x.IsCompleted
            })
            .OrderByDescending(x => x.ServiceDate)
            .ToArrayAsync(cancellationToken);
    }
}