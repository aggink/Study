using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Formula1.Drivers.DtoModels;

namespace Study.Lab3.Web.Features.Formula1.Drivers.Queries;

/// <summary>
/// Получить список гонщиков
/// </summary>
public class GetListDriversQuery : IRequest<DriverItemDto[]>
{ }

public class GetListDriversQueryHandler : IRequestHandler<GetListDriversQuery, DriverItemDto[]>
{
    private readonly DataContext _dataContext;

    public GetListDriversQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<DriverItemDto[]> Handle(GetListDriversQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Drivers
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .Select(x => new DriverItemDto
            {
                IsnDriver = x.IsnDriver,
                TeamName = x.Team.Name,
                Name = x.Name,
                Age = x.Age,
                CountryOfOrigin = x.CountryOfOrigin
            })
            .ToArrayAsync(cancellationToken);
    }
}