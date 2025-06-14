using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.CarService;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.CarService;
using Study.Lab3.Web.Features.CarService.Cars.DtoModels;

namespace Study.Lab3.Web.Features.CarService.Cars.Commands;

public sealed class CreateCarCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные автомобиля
    /// </summary>
    [Required]
    [FromBody]
    public CreateCarDto Car { get; init; }
}
 
public sealed class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly ICarService _carService;
 
    public CreateCarCommandHandler(
        DataContext dataContext,
        ICarService carService)
    {
        _dataContext = dataContext;
        _carService = carService;
    }
 
    public async Task<Guid> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var car = new Car
        {
            IsnCar = Guid.NewGuid(),
            IsnOwner = request.Car.IsnOwner,
            Brand = request.Car.Brand,
            Model = request.Car.Model,
            Year = request.Car.Year,
            LicensePlate = request.Car.LicensePlate,
            VinNumber = request.Car.VinNumber,
            Color = request.Car.Color,
            Mileage = request.Car.Mileage
        };
 
        await _carService.CreateOrUpdateCarValidateAndThrowAsync(
            _dataContext, car, cancellationToken);
 
        await _dataContext.Cars.AddAsync(car, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
 
        return car.IsnCar;
    }
}