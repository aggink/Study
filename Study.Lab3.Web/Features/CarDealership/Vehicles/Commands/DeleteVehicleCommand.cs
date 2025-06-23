using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CarDealership;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.CarDealership.Vehicles.Commands;

/// <summary>
/// Удаление автомобиля
/// </summary>
public sealed class DeleteVehicleCommand : IRequest
{
    /// <summary>
    /// Идентификатор автомобиля
    /// </summary>
    [Required]
    public Guid IsnVehicle { get; init; }
}

public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand>
{
    private readonly DataContext _dataContext;
    private readonly IVehicleService _vehicleService;

    public DeleteVehicleCommandHandler(
        DataContext dataContext,
        IVehicleService vehicleService)
    {
        _dataContext = dataContext;
        _vehicleService = vehicleService;
    }

    public async Task Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _dataContext.Vehicles
            .FirstOrDefaultAsync(x => x.IsnVehicle == request.IsnVehicle, cancellationToken);

        if (vehicle == null)
            throw new InvalidOperationException($"Автомобиль с идентификатором {request.IsnVehicle} не найден");

        await _vehicleService.CanDeleteAndThrowAsync(_dataContext, vehicle, cancellationToken);

        _dataContext.Vehicles.Remove(vehicle);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}