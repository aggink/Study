using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.BeautySalon;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.BeautySalon.BeautyService.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.BeautySalon.BeautyService.Commands;

/// <summary>
/// Редактирование услуги
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
    private readonly IBeautyServiceService _serviceService;

    public UpdateServiceCommandHandler(DataContext dataContext, IBeautyServiceService serviceService)
    {
        _dataContext = dataContext;
        _serviceService = serviceService;
    }

    public async Task<Guid> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = await _dataContext.BeautyService.FirstOrDefaultAsync(x => x.IsnService == request.Service.IsnService, cancellationToken)
                ?? throw new BusinessLogicException($"Услуги с идентификатором \"{request.Service.IsnService}\" не существует!");

        service.ServiceName = request.Service.ServiceName;
        service.Description = request.Service.Description;
        service.Price = request.Service.Price;
        service.Duration = request.Service.Duration;

        await _serviceService.CreateOrUpdateBeautyServiceValidateAndThrowAsync(_dataContext, service, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return service.IsnService;
    }
}