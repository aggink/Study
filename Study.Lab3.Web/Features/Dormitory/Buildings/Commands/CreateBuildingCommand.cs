using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Dormitory;
using Study.Lab3.Web.Features.Dormitory.Buildings.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Dormitory.Buildings.Commands;

/// <summary>
/// Создание здания общежития
/// </summary>
public sealed class CreateBuildingCommand : IRequest<int>
{
    /// <summary>
    /// Данные здания
    /// </summary>
    [Required]
    [FromBody]
    public CreateDormitoryBuildingDto Building { get; init; }
}

public sealed class CreateBuildingCommandHandler : IRequestHandler<CreateBuildingCommand, int>
{
    private readonly DataContext _dataContext;

    public CreateBuildingCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<int> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
    {
        var building = new DormitoryBuilding
        {
            Name = request.Building.Name,
            Address = request.Building.Address,
            FloorsCount = request.Building.FloorsCount,
            TotalRooms = request.Building.TotalRooms,
            BuildYear = request.Building.BuildYear,
            ManagerName = request.Building.ManagerName,
            ManagerPhone = request.Building.ManagerPhone,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _dataContext.DormitoryBuildings.AddAsync(building, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return building.Id;
    }
}
