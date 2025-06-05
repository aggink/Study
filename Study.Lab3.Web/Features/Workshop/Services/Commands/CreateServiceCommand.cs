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
    private readonly IServiceService _serviceService;

    public CreateServiceCommandHandler(
        DataContext dataContext,
        IServiceService serviceService)
    {
        _dataContext = dataContext;
        _serviceService = serviceService;
    }

    public async Task<Guid> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = new Service
        {
            IsnService = Guid.NewGuid(),
            Name = request.Service.Name,
            Description = request.Service.Description,
            Price = request.Service.Price,
            Duration = request.Service.Duration
        };

        await _serviceService.CreateOrUpdateServiceValidateAndThrowAsync(
            _dataContext, service, cancellationToken);

        await _dataContext.Services.AddAsync(service, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return service.IsnService;
    }
}