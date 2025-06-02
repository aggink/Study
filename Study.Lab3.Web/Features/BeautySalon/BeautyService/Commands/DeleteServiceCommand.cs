using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.BeautySalon;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.BeautySalon.BeautyService.Commands;

/// <summary>
/// Удаление услуги
/// </summary>
public sealed class DeleteServiceCommand : IRequest
{
    /// <summary>
    /// Идентификатор услуги
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnService { get; init; }
}

public sealed class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand>
{
    private readonly DataContext _dataContext;
    private readonly IBeautyServiceService _serviceService;

    public DeleteServiceCommandHandler(DataContext dataContext, IBeautyServiceService serviceService)
    {
        _dataContext = dataContext;
        _serviceService = serviceService;
    }

    public async Task Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        var service = await _dataContext.BeautyServices.FirstOrDefaultAsync(x => x.IsnService == request.IsnService, cancellationToken)
                ?? throw new BusinessLogicException($"Услуги с идентификатором \"{request.IsnService}\" не существует!");

        _dataContext.BeautyServices.Remove(service);
        await _dataContext.SaveChangesAsync(cancellationToken);
        return;
    }
}