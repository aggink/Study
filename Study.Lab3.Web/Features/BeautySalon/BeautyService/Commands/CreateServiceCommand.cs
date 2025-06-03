using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.BeautySalon;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.BeautySalon.BeautyService.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.BeautySalon.BeautyService.Commands;

/// <summary>
/// Создание услуги
/// </summary>
public sealed class CreateServiceCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные услуги
    /// </summary>
    [Required]
    [FromBody]
    public CreateServiceDto Service { get; init; }
}

public sealed class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IBeautyServiceService _serviceService;

    public CreateServiceCommandHandler(DataContext dataContext, IBeautyServiceService serviceService)
    {
        _dataContext = dataContext;
        _serviceService = serviceService;
    }

    public async Task<Guid> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = new Storage.Models.BeautySalon.BeautyService
        {
            IsnService = Guid.NewGuid(),
            ServiceName = request.Service.ServiceName,
            Description = request.Service.Description,
            Price = request.Service.Price,
            Duration = request.Service.Duration,
        };

        await _serviceService.CreateOrUpdateBeautyServiceValidateAndThrowAsync(_dataContext, service, cancellationToken);

        await _dataContext.BeautyService.AddAsync(service, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return service.IsnService;
    }
}