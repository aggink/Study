using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Workshop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Workshop;
using Study.Lab3.Web.Features.Workshop.Services.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Workshop.Services.Commands;

/// <summary>
/// Создание услуги
/// </summary>
public sealed class CreateWorkshopServiceCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные услуги
    /// </summary>
    [Required]
    [FromBody]
    public CreateWorkshopServiceDto WorkshopService { get; init; }
}

public sealed class CreateServiceCommandHandler : IRequestHandler<CreateWorkshopServiceCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IServiceService _serviceService;

    public CreateServiceCommandHandler(
        DataContext dataContext,
        IServiceService serviceService)
    {
        _dataContext = dataContext;
        _serviceService = serviceService;
    }

    public async Task<Guid> Handle(CreateWorkshopServiceCommand request, CancellationToken cancellationToken)
    {
        var service = new Service
        {
            IsnService = Guid.NewGuid(),
            Name = request.WorkshopService.Name,
            Description = request.WorkshopService.Description,
            Price = request.WorkshopService.Price,
            Duration = request.WorkshopService.Duration
        };

        await _serviceService.CreateOrUpdateServiceValidateAndThrowAsync(
            _dataContext, service, cancellationToken);

        await _dataContext.Services.AddAsync(service, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return service.IsnService;
    }
}