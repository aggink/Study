using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.BeautySalon.BeautyService.DtoModels;

namespace Study.Lab3.Web.Features.BeautySalon.BeautyService.Queries;

/// <summary>
/// Получение списка услуг
/// </summary>
public sealed class GetListServicesQuery : IRequest<ServiceDto[]>
{
}

public sealed class GetListServicesQueryHandler : IRequestHandler<GetListServicesQuery, ServiceDto[]>
{
    private readonly DataContext _dataContext;

    public GetListServicesQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ServiceDto[]> Handle(GetListServicesQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.BeautyService
            .AsNoTracking()
            .Select(x => new ServiceDto
            {
                IsnService = x.IsnService,
                ServiceName = x.ServiceName,
                Description = x.Description,
                Price = x.Price,
                Duration = x.Duration
            })
            .OrderBy(x => x.ServiceName) // Сортировка по названию услуги
            .ToArrayAsync(cancellationToken);
    }
}