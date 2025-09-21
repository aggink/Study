using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Formula1.Teams.DtoModels;

namespace Study.Lab3.Web.Features.Formula1.Teams.Queries;

/// <summary>
/// Получить данные команды
/// </summary>
public sealed class GetTeamByIsnQuery : IRequest<TeamDto>
{
    /// <summary>
    /// Идентификатор команды
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnTeam { get; init; }
}

public sealed class GetTeamByIsnQueryHandler : IRequestHandler<GetTeamByIsnQuery, TeamDto>
{
    private readonly DataContext _dataContext;

    public GetTeamByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<TeamDto> Handle(GetTeamByIsnQuery request, CancellationToken cancellationToken)
    {
        var team = await _dataContext.Teams
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnTeam == request.IsnTeam, cancellationToken)
                ?? throw new BusinessLogicException($"Команды с идентификатором \"{request.IsnTeam}\" не существует");

        return new TeamDto
        {
            IsnTeam = team.IsnTeam,
            Name = team.Name,
            YearOfCreation = team.YearOfCreation,
            EngineSupplier = team.EngineSupplier
        };
    }
}
