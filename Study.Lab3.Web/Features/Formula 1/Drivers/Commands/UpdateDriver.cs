using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Formula1.Drivers.DtoModels;

namespace Study.Lab3.Web.Features.Formula1.Drivers.Commands;

/// <summary>
/// Редактирование данных гонщика
/// </summary>
public sealed class UpdateDriverCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные гонщика
    /// </summary>
    [Required]
    [FromBody]
    public UpdateDriverDto Driver { get; init; }
}

public sealed class UpdateDriverCommandHandler : IRequestHandler<UpdateDriverCommand, Guid>
{
    private readonly DataContext _dataContext;

    public UpdateDriverCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(UpdateDriverCommand request, CancellationToken cancellationToken)
    {
        var driver = await _dataContext.Drivers.FirstOrDefaultAsync(x => x.IsnDriver == request.Driver.IsnDriver, cancellationToken)
            ?? throw new BusinessLogicException($"Гонщика с идентификатором \"{request.Driver.IsnDriver}\" не существует");

        if (driver.IsnTeam != request.Driver.IsnTeam && !await _dataContext.Teams.AnyAsync(x => x.IsnTeam == request.Driver.IsnTeam, cancellationToken))
            throw new BusinessLogicException($"Команды с идентификатором \"{request.Driver.IsnTeam}\" не существует");

        driver.IsnTeam = request.Driver.IsnTeam;
        driver.Name = request.Driver.Name;
        driver.Age = request.Driver.Age;
        driver.CountryOfOrigin = request.Driver.CountryOfOrigin;

        await _dataContext.SaveChangesAsync(cancellationToken);
        return driver.IsnDriver;
    }
}
