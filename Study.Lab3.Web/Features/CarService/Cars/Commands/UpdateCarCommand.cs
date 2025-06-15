using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CarService;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CarService.Cars.DtoModels;

namespace Study.Lab3.Web.Features.CarService.Cars.Commands;

public sealed class UpdateCarCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные автомобиля
    /// </summary>
    [Required]
    [FromBody]
    public UpdateCarDto Car { get; init; }
}
 
public sealed class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly ICarService _carService;
 
    public UpdateCarCommandHandler(
        DataContext dataContext,
        ICarService carService)
    {
        _dataContext = dataContext;
        _carService = carService;
    }
 
    public async Task<Guid> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        var car = await _dataContext.Cars
                      .FirstOrDefaultAsync(x => x.IsnCar == request.Car.IsnCar, cancellationToken)
                  ?? throw new BusinessLogicException($"Автомобиль с идентификатором \"{request.Car.IsnCar}\" не существует");
 
        car.Brand = request.Car.Brand;
        car.Model = request.Car.Model;
        car.Year = request.Car.Year;
        car.LicensePlate = request.Car.LicensePlate;
        car.VinNumber = request.Car.VinNumber;
        car.Color = request.Car.Color;
        car.Mileage = request.Car.Mileage;
 
        await _carService.CreateOrUpdateCarValidateAndThrowAsync(
            _dataContext, car, cancellationToken);
 
        await _dataContext.SaveChangesAsync(cancellationToken);
        return car.IsnCar;
    }
}