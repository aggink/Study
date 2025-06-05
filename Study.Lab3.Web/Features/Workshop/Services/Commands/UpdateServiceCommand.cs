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
public sealed class UpdateServiceCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные услуги
    /// </summary>
    [Required]
    [FromBody]
    public UpdateServiceDto Service { get; init; }
}

public sealed class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, Guid>
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

    public async Task<Guid> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = await _dataContext.Services
                          .FirstOrDefaultAsync(x => x.IsnService == request.Service.IsnService, cancellationToken)
                      ?? throw new BusinessLogicException(
                          $"Услуга с идентификатором \"{request.Service.IsnService}\" не существует");

        service.Name = request.Service.Name;
        service.Description = request.Service.Description;
        service.Price = request.Service.Price;
        service.Duration = request.Service.Duration;

        await _serviceService.CreateOrUpdateServiceValidateAndThrowAsync(
            _dataContext, service, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return service.IsnService;
    }
}