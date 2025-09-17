using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Formula1.Drivers.DtoModels;

namespace Study.Lab3.Web.Features.Formula1.Drivers.Queries;

/// <summary>
/// Получить данные пилота
/// </summary>
public sealed class GetDriverByIsnQuery : IRequest<DriverDto>
{
    /// <summary>
    /// Идентификатор пилота
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnDriver { get; init; }
}

public sealed class GetDriverByIsnQueryHandler : IRequestHandler<GetDriverByIsnQuery, DriverDto>
{
    private readonly DataContext _dataContext;

    public GetDriverByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<DriverDto> Handle(GetDriverByIsnQuery request, CancellationToken cancellationToken)
    {
        var driver = await _dataContext.Drivers
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnDriver == request.IsnDriver, cancellationToken)
                ?? throw new BusinessLogicException($"Гонщика с идентификатором \"{request.IsnDriver}\" не существует");

        return new DriverDto
        {
            IsnDriver = driver.IsnDriver,
            IsnTeam = driver.IsnTeam,
            Name = driver.Name,
            Age = driver.Age,
            CountryOfOrigin = driver.CountryOfOrigin
        };
    }
}
