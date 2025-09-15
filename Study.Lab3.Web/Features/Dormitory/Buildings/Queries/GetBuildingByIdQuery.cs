using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Dormitory.Buildings.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Dormitory.Buildings.Queries;

/// <summary>
/// Получение здания общежития по ID
/// </summary>
public sealed class GetBuildingByIdQuery : IRequest<DormitoryBuildingDto?>
{
    /// <summary>
    /// Идентификатор здания
    /// </summary>
    [Required]
    [FromRoute]
    public int Id { get; init; }
}

public sealed class GetBuildingByIdQueryHandler : IRequestHandler<GetBuildingByIdQuery, DormitoryBuildingDto?>
{
    private readonly DataContext _dataContext;

    public GetBuildingByIdQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<DormitoryBuildingDto?> Handle(GetBuildingByIdQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.DormitoryBuildings
            .AsNoTracking()
            .Where(x => x.Id == request.Id)
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
            .FirstOrDefaultAsync(cancellationToken);
    }
}
