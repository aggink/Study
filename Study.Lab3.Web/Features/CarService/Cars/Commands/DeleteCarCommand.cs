using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CarService;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.CarService.Cars.Commands;

public sealed class DeleteCarCommand : IRequest
{
    /// <summary>
    /// Идентификатор автомобиля
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnCar { get; init; }
}
 
public sealed class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand>
{
    private readonly DataContext _dataContext;
    private readonly ICarService _carService;
 
    public DeleteCarCommandHandler(
        DataContext dataContext,
        ICarService carService)
    {
        _dataContext = dataContext;
        _carService = carService;
    }
 
    public async Task Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        var car = await _dataContext.Cars
                      .FirstOrDefaultAsync(x => x.IsnCar == request.IsnCar, cancellationToken)
                  ?? throw new BusinessLogicException($"Автомобиль с идентификатором \"{request.IsnCar}\" не существует");
 
        await _carService.CanDeleteAndThrowAsync(
            _dataContext, car, cancellationToken);
 
        _dataContext.Cars.Remove(car);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}