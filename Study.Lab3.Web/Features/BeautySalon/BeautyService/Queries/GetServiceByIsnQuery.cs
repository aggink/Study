using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.BeautySalon.BeautyService.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.BeautySalon.BeautyService.Queries;

/// <summary>
/// Получение данных услуги
/// </summary>
public class GetServiceByIsnQuery : IRequest<ServiceDto>
{
    /// <summary>
    /// ID услуги
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
        var service = await _dataContext.BeautyService
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnService == request.IsnService, cancellationToken)
            ?? throw new BusinessLogicException($"Услуги с идентификатором \"{request.IsnService}\" не существует!");

        return new ServiceDto
        {
            IsnService = service.IsnService,
            ServiceName = service.ServiceName,
            Description = service.Description,
            Price = service.Price,
            Duration = service.Duration
        };
    }
}