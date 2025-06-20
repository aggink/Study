using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CarDealership.Vehicles.DtoModels;

namespace Study.Lab3.Web.Features.CarDealership.Vehicles.Queries;

/// <summary>
/// Получение списка автомобилей
/// </summary>
public sealed class GetVehiclesListQuery : IRequest<VehicleDto[]>
{
}

public class GetVehiclesListQueryHandler : IRequestHandler<GetVehiclesListQuery, VehicleDto[]>
{
    private readonly DataContext _dataContext;

    public GetVehiclesListQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<VehicleDto[]> Handle(GetVehiclesListQuery request, CancellationToken cancellationToken)
    {
        var vehicles = await _dataContext.Vehicles
            .Select(vehicle => new VehicleDto
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
            })
            .ToArrayAsync(cancellationToken);

        return vehicles;
    }
}