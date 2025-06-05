using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Workshop.Services.DtoModels;

namespace Study.Lab3.Web.Features.Workshop.Services.Queries;

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
        return await _dataContext.Services
            .AsNoTracking()
            .Select(x => new ServiceDto
            {
                IsnService = x.IsnService,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Duration = x.Duration
            })
            .OrderBy(x => x.Name)
            .ToArrayAsync(cancellationToken);
    }
}
