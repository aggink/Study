using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Workshop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Workshop.Services.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Workshop.Services.Commands;

/// <summary>
/// Обновление услуги
/// </summary>
public sealed class UpdateWorkshopServiceCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные услуги
    /// </summary>
    [Required]
    [FromBody]
    public UpdateServiceServiceDto ServiceService { get; init; }
}

public sealed class UpdateServiceCommandHandler : IRequestHandler<UpdateWorkshopServiceCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IServiceService _serviceService;

    public UpdateServiceCommandHandler(
        DataContext dataContext,
        IServiceService serviceService)
    {
        _dataContext = dataContext;
        _serviceService = serviceService;
    }

    public async Task<Guid> Handle(UpdateWorkshopServiceCommand request, CancellationToken cancellationToken)
    {
        var service = await _dataContext.Services
                          .FirstOrDefaultAsync(x => x.IsnService == request.ServiceService.IsnService, cancellationToken)
                      ?? throw new BusinessLogicException(
                          $"Услуга с идентификатором \"{request.ServiceService.IsnService}\" не существует");

        service.Name = request.ServiceService.Name;
        service.Description = request.ServiceService.Description;
        service.Price = request.ServiceService.Price;
        service.Duration = request.ServiceService.Duration;

        await _serviceService.CreateOrUpdateServiceValidateAndThrowAsync(
            _dataContext, service, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return service.IsnService;
    }
}