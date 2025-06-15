using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CarService.Cars.DtoModels;

namespace Study.Lab3.Web.Features.CarService.Cars.Queries;

public sealed class GetCarByIsnQuery : IRequest<CarDto>
{
    /// <summary>
    /// Идентификатор автомобиля
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnCar { get; init; }
}
 
public sealed class GetCarByIsnQueryHandler : IRequestHandler<GetCarByIsnQuery, CarDto>
{
    private readonly DataContext _dataContext;
 
    public GetCarByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
 
    public async Task<CarDto> Handle(GetCarByIsnQuery request, CancellationToken cancellationToken)
    {
        var car = await _dataContext.Cars
                      .AsNoTracking()
                      .FirstOrDefaultAsync(x => x.IsnCar == request.IsnCar, cancellationToken)
                  ?? throw new BusinessLogicException($"Автомобиль с идентификатором \"{request.IsnCar}\" не существует");
 
        return new CarDto
        {
            IsnCar = car.IsnCar,
            IsnOwner = car.IsnOwner,
            Brand = car.Brand,
            Model = car.Model,
            Year = car.Year,
            LicensePlate = car.LicensePlate,
            VinNumber = car.VinNumber,
            Color = car.Color,
            Mileage = car.Mileage
        };
    }
}