using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Workshop.Services.DtoModels;

namespace Study.Lab3.Web.Features.Workshop.Services.Queries;

/// <summary>
/// Получение списка услуг
/// </summary>
public sealed class GetListWorkshopServiceQuery : IRequest<WorkshopServiceDto[]>
{
}

public sealed class GetListServicesQueryHandler : IRequestHandler<GetListWorkshopServiceQuery, WorkshopServiceDto[]>
{
    private readonly DataContext _dataContext;

    public GetListServicesQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<WorkshopServiceDto[]> Handle(GetListWorkshopServiceQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Services
            .AsNoTracking()
            .Select(x => new WorkshopServiceDto
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
