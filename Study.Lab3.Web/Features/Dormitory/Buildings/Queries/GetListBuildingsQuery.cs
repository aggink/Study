using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Dormitory.Buildings.DtoModels;

namespace Study.Lab3.Web.Features.Dormitory.Buildings.Queries;

/// <summary>
/// Получение списка зданий общежитий
/// </summary>
public sealed class GetListBuildingsQuery : IRequest<DormitoryBuildingDto[]>
{
}

public sealed class GetListBuildingsQueryHandler : IRequestHandler<GetListBuildingsQuery, DormitoryBuildingDto[]>
{
    private readonly DataContext _dataContext;

    public GetListBuildingsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<DormitoryBuildingDto[]> Handle(GetListBuildingsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.DormitoryBuildings
            .AsNoTracking()
            .Select(x => new DormitoryBuildingDto
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                FloorsCount = x.FloorsCount,
                TotalRooms = x.TotalRooms,
                BuildYear = x.BuildYear,
                ManagerName = x.ManagerName,
                ManagerPhone = x.ManagerPhone,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            })
            .OrderBy(x => x.Name)
            .ToArrayAsync(cancellationToken);
    }
}
