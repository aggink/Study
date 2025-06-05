using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Workshop.Services.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Workshop.Services.Queries;

/// <summary>
/// Получить услугу по идентификатору
/// </summary>
public sealed class GetServiceByIsnQuery : IRequest<ServiceDto>
{
    /// <summary>
    /// Идентификатор услуги
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnService { get; init; }
}

public sealed class GetServiceByIsnQueryHandler : IRequestHandler<GetServiceByIsnQuery, ServiceDto>
{
    private readonly DataContext _dataContext;

    public GetServiceByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ServiceDto> Handle(GetServiceByIsnQuery request, CancellationToken cancellationToken)
    {
        var service = await _dataContext.Services
                          .AsNoTracking()
                          .FirstOrDefaultAsync(x => x.IsnService == request.IsnService, cancellationToken)
                      ?? throw new BusinessLogicException(
                          $"Услуга с идентификатором \"{request.IsnService}\" не существует");

        return new ServiceDto
        {
            IsnService = service.IsnService,
            Name = service.Name,
            Description = service.Description,
            Price = service.Price,
            Duration = service.Duration
        };
    }
}
