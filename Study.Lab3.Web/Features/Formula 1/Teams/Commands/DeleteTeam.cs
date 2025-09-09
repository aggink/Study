using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.Formula1.Teams.Commands;

/// <summary>
/// Удаление команды
/// </summary>
public sealed class DeleteTeamCommand : IRequest
{
    /// <summary>
    /// Идентификатор команды
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnTeam { get; init; }
}

public sealed class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand>
{
    private readonly DataContext _dataContext;

    public DeleteTeamCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
    {
        var team = await _dataContext.Teams.FirstOrDefaultAsync(x => x.IsnTeam == request.IsnTeam, cancellationToken)
            ?? throw new BusinessLogicException($"Команды с идентификатором \"{request.IsnTeam}\" не существует");

        _dataContext.Teams.Remove(team);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return;
    }
}