using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.CarDealership;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.CarDealership;
using Study.Lab3.Web.Features.CarDealership.Vehicles.DtoModels;

namespace Study.Lab3.Web.Features.CarDealership.Vehicles.Commands;

/// <summary>
/// Создание автомобиля
/// </summary>
public sealed class CreateVehicleCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные автомобиля
    /// </summary>
    [Required]
    [FromBody]
    public CreateVehicleDto Vehicle { get; init; }
}

public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IVehicleService _vehicleService;

    public CreateVehicleCommandHandler(
        DataContext dataContext,
        IVehicleService vehicleService)
    {
        _dataContext = dataContext;
        _vehicleService = vehicleService;
    }

    public async Task<Guid> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = new Vehicle
        {
            IsnVehicle = Guid.NewGuid(),
            Brand = request.Vehicle.Brand,
            Model = request.Vehicle.Model,
            Year = request.Vehicle.Year,
            Color = request.Vehicle.Color,
            VinNumber = request.Vehicle.VinNumber,
            Mileage = request.Vehicle.Mileage,
            Price = request.Vehicle.Price,
            IsAvailable = request.Vehicle.IsAvailable,
            ArrivalDate = DateTime.UtcNow
        };

        await _vehicleService.CreateOrUpdateVehicleValidateAndThrowAsync(_dataContext, vehicle, cancellationToken);

        _dataContext.Vehicles.Add(vehicle);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return vehicle.IsnVehicle;
    }
}