using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Formula1;
using Study.Lab3.Web.Features.Formula1.Teams.DtoModels;

namespace Study.Lab3.Web.Features.Formula1.Teams.Commands;

/// <summary>
/// Создание команды
/// </summary>
public sealed class CreateTeamCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные команды
    /// </summary>
    [Required]
    [FromBody]
    public CreateTeamDto Team { get; init; }
}

public sealed class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, Guid>
{
    private readonly DataContext _dataContext;

    public CreateTeamCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
    {

        var team = new Team
        {
            IsnTeam = Guid.NewGuid(),
            Name = request.Team.Name,
            YearOfCreation = request.Team.YearOfCreation,
            EngineSupplier = request.Team.EngineSupplier
        };

        await _dataContext.Teams.AddAsync(team, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return team.IsnTeam;
    }
}
