using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Workshop;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Workshop.Services.Commands;

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
    private readonly IServiceService _serviceService;

    public DeleteServiceCommandHandler(
        DataContext dataContext,
        IServiceService serviceService)
    {
        _dataContext = dataContext;
        _serviceService = serviceService;
    }

    public async Task Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        var service = await _dataContext.Services
                          .FirstOrDefaultAsync(x => x.IsnService == request.IsnService, cancellationToken)
                      ?? throw new BusinessLogicException(
                          $"Услуга с идентификатором \"{request.IsnService}\" не существует");

        await _serviceService.CanDeleteAndThrowAsync(_dataContext, service, cancellationToken);

        _dataContext.Services.Remove(service);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}
