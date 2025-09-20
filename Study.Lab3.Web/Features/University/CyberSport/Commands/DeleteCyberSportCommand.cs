using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.CyberSport.Commands;

/// <summary>
/// Удаление киберспорта
/// </summary>
public sealed class DeleteCyberSportCommand : IRequest
{
    /// <summary>
    /// Идентификатор киберспорта
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnCyberSport { get; init; }
}

public sealed class DeleteCyberSportCommandHandler : IRequestHandler<DeleteCyberSportCommand>
{
    private readonly DataContext _dataContext;
    private readonly ICyberSportService _cyberSportService;

    public DeleteCyberSportCommandHandler(
        DataContext dataContext,
        ICyberSportService cyberSportService)
    {
        _dataContext = dataContext;
        _cyberSportService = cyberSportService;
    }

    public async Task Handle(DeleteCyberSportCommand request, CancellationToken cancellationToken)
    {
        var cyberSport = await _dataContext.CyberSport
            .Include(x => x.Subject)
            .FirstOrDefaultAsync(x => x.IsnCyberSport == request.IsnCyberSport, cancellationToken)
                ?? throw new BusinessLogicException($"Соревнований с идентификатором \"{request.IsnCyberSport}\" не существует");

        await _cyberSportService.CanDeleteAndThrowAsync(
            _dataContext, cyberSport, cancellationToken);

        _dataContext.CyberSport.Remove(cyberSport);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}