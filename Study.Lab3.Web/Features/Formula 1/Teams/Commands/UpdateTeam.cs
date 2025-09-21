using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Formula1.Teams.DtoModels;

namespace Study.Lab3.Web.Features.Formula1.Teams.Commands;

/// <summary>
/// Редактирование данных команды
/// </summary>
public sealed class UpdateTeamCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные команды
    /// </summary>
    [Required]
    [FromBody]
    public UpdateTeamDto Team { get; init; }
}

public sealed class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand, Guid>
{
    private readonly DataContext _dataContext;

    public UpdateTeamCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
    {
        var team = await _dataContext.Teams.FirstOrDefaultAsync(x => x.IsnTeam == request.Team.IsnTeam, cancellationToken)
            ?? throw new BusinessLogicException($"Команды с идентификатором \"{request.Team.IsnTeam}\" не существует");

        team.IsnTeam = request.Team.IsnTeam;
        team.Name = request.Team.Name;
        team.YearOfCreation = request.Team.YearOfCreation;
        team.EngineSupplier = request.Team.EngineSupplier;

        await _dataContext.SaveChangesAsync(cancellationToken);
        return team.IsnTeam;
    }
}
