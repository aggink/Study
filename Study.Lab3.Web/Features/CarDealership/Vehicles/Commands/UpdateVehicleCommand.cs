using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CarDealership;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CarDealership.Vehicles.DtoModels;

namespace Study.Lab3.Web.Features.CarDealership.Vehicles.Commands;

/// <summary>
/// Обновление автомобиля
/// </summary>
public sealed class UpdateVehicleCommand : IRequest<Guid>
{
    /// <summary>
    /// Идентификатор автомобиля
    /// </summary>
    [Required]
    public Guid IsnVehicle { get; init; }
    
    /// <summary>
    /// Данные автомобиля
    /// </summary>
    [Required]
    [FromBody]
    public UpdateVehicleDto Vehicle { get; init; }
}

public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IVehicleService _vehicleService;

    public UpdateVehicleCommandHandler(
        DataContext dataContext,
        IVehicleService vehicleService)
    {
        _dataContext = dataContext;
        _vehicleService = vehicleService;
    }

    public async Task<Guid> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _dataContext.Vehicles
            .FirstOrDefaultAsync(x => x.IsnVehicle == request.IsnVehicle, cancellationToken);

        if (vehicle == null)
            throw new InvalidOperationException($"Автомобиль с идентификатором {request.IsnVehicle} не найден");

        vehicle.Brand = request.Vehicle.Brand;
        vehicle.Model = request.Vehicle.Model;
        vehicle.Year = request.Vehicle.Year;
        vehicle.Color = request.Vehicle.Color;
        vehicle.VinNumber = request.Vehicle.VinNumber;
        vehicle.Mileage = request.Vehicle.Mileage;
        vehicle.Price = request.Vehicle.Price;
        vehicle.IsAvailable = request.Vehicle.IsAvailable;

        await _vehicleService.CreateOrUpdateVehicleValidateAndThrowAsync(_dataContext, vehicle, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return vehicle.IsnVehicle;
    }
}