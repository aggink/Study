using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CarDealership.Vehicles.DtoModels;

namespace Study.Lab3.Web.Features.CarDealership.Vehicles.Queries;

/// <summary>
/// Получение автомобиля по идентификатору
/// </summary>
public sealed class GetVehicleByIdQuery : IRequest<VehicleDto>
{
    /// <summary>
    /// Идентификатор автомобиля
    /// </summary>
    public Guid Id { get; init; }
}

public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, VehicleDto>
{
    private readonly DataContext _dataContext;

    public GetVehicleByIdQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<VehicleDto> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
    {
        var vehicle = await _dataContext.Vehicles
            .FirstOrDefaultAsync(x => x.IsnVehicle == request.Id, cancellationToken);

        if (vehicle == null)
            throw new InvalidOperationException($"Автомобиль с идентификатором {request.Id} не найден");

        return new VehicleDto
        {
            IsnVehicle = vehicle.IsnVehicle,
            Brand = vehicle.Brand,
            Model = vehicle.Model,
            Year = vehicle.Year,
            Color = vehicle.Color,
            VinNumber = vehicle.VinNumber,
            Mileage = vehicle.Mileage,
            Price = vehicle.Price,
            IsAvailable = vehicle.IsAvailable,
            ArrivalDate = vehicle.ArrivalDate
        };
    }
}