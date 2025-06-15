using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CarService.Cars.DtoModels;

namespace Study.Lab3.Web.Features.CarService.Cars.Queries;

public sealed class GetListCarsQuery : IRequest<CarDto[]>
{
}
 
public sealed class GetListCarsQueryHandler : IRequestHandler<GetListCarsQuery, CarDto[]>
{
    private readonly DataContext _dataContext;
 
    public GetListCarsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
 
    public async Task<CarDto[]> Handle(GetListCarsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Cars
            .AsNoTracking()
            .Select(x => new CarDto
            {
                IsnCar = x.IsnCar,
                IsnOwner = x.IsnOwner,
                Brand = x.Brand,
                Model = x.Model,
                Year = x.Year,
                LicensePlate = x.LicensePlate,
                VinNumber = x.VinNumber,
                Color = x.Color,
                Mileage = x.Mileage
            })
            .OrderBy(x => x.Brand)
            .ThenBy(x => x.Model)
            .ToArrayAsync(cancellationToken);
    }
}