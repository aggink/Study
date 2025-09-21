using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Formula1;
using Study.Lab3.Web.Features.Formula1.Drivers.DtoModels;

namespace Study.Lab3.Web.Features.Formula1.Drivers.Commands;

/// <summary>
/// Создание гонщика
/// </summary>
public sealed class CreateDriverCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные гонщика
    /// </summary>
    [Required]
    [FromBody]
    public CreateDriverDto Driver { get; init; }
}

public sealed class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, Guid>
{
    private readonly DataContext _dataContext;

    public CreateDriverCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
    {
        var team = await _dataContext.Teams.FirstOrDefaultAsync(x => x.IsnTeam == request.Driver.IsnTeam, cancellationToken)
           ?? throw new BusinessLogicException($"Команды с идентификатором \"{request.Driver.IsnTeam}\" не существует");

        var driver = new Driver
        {
            IsnDriver = Guid.NewGuid(),
            IsnTeam = request.Driver.IsnTeam,
            Name = request.Driver.Name,
            Age = request.Driver.Age,
            CountryOfOrigin = request.Driver.CountryOfOrigin,
            Team = team
        };

        await _dataContext.Drivers.AddAsync(driver, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return driver.IsnDriver;
    }
}
