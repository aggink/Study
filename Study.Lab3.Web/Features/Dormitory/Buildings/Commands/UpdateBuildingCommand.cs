using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Dormitory.Buildings.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Dormitory.Buildings.Commands;

/// <summary>
/// Обновление здания общежития
/// </summary>
public sealed class UpdateBuildingCommand : IRequest<Unit>
{
    /// <summary>
    /// Идентификатор здания
    /// </summary>
    [Required]
    [FromRoute]
    public int Id { get; init; }

    /// <summary>
    /// Данные для обновления
    /// </summary>
    [Required]
    [FromBody]
    public UpdateDormitoryBuildingDto Building { get; init; }
}

public sealed class UpdateBuildingCommandHandler : IRequestHandler<UpdateBuildingCommand, Unit>
{
    private readonly DataContext _dataContext;

    public UpdateBuildingCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Unit> Handle(UpdateBuildingCommand request, CancellationToken cancellationToken)
    {
        var building = await _dataContext.DormitoryBuildings
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (building == null)
        {
            throw new ArgumentException($"Здание с ID {request.Id} не найдено");
        }

        building.Name = request.Building.Name;
        building.Address = request.Building.Address;
        building.FloorsCount = request.Building.FloorsCount;
        building.TotalRooms = request.Building.TotalRooms;
        building.BuildYear = request.Building.BuildYear;
        building.ManagerName = request.Building.ManagerName;
        building.ManagerPhone = request.Building.ManagerPhone;
        building.UpdatedAt = DateTime.UtcNow;

        await _dataContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
