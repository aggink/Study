using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Dormitory.Buildings.Commands;

/// <summary>
/// Удаление здания общежития
/// </summary>
public sealed class DeleteBuildingCommand : IRequest<Unit>
{
    /// <summary>
    /// Идентификатор здания
    /// </summary>
    [Required]
    [FromRoute]
    public int Id { get; init; }
}

public sealed class DeleteBuildingCommandHandler : IRequestHandler<DeleteBuildingCommand, Unit>
{
    private readonly DataContext _dataContext;

    public DeleteBuildingCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Unit> Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
    {
        var building = await _dataContext.DormitoryBuildings
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (building == null)
        {
            throw new ArgumentException($"Здание с ID {request.Id} не найдено");
        }

        _dataContext.DormitoryBuildings.Remove(building);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
