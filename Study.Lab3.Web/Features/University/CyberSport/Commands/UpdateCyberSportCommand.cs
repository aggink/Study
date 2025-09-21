using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.CyberSport.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.CyberSport.Commands;

/// <summary>
/// Редактирование киберспорта
/// </summary>
public sealed class UpdateCyberSportCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные кабиреспорта
    /// </summary>
    [Required]
    [FromBody]
    public UpdateCyberSportDto CyberSport { get; init; }
}

public sealed class UpdateCyberSportCommandHandler : IRequestHandler<UpdateCyberSportCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly ICyberSportService _CyberSportService;

    public UpdateCyberSportCommandHandler(
        DataContext dataContext,
        ICyberSportService CyberSportService)
    {
        _dataContext = dataContext;
        _CyberSportService = CyberSportService;
    }

    public async Task<Guid> Handle(UpdateCyberSportCommand request, CancellationToken cancellationToken)
    {
        var cyberSport = await _dataContext.CyberSport
            .Include(x => x.Subject)
            .FirstOrDefaultAsync(x => x.IsnCyberSport == request.CyberSport.IsnCyberSport, cancellationToken)
                ?? throw new BusinessLogicException($"Соревнований с идентификатором \"{request.CyberSport.IsnCyberSport}\" не существует");

        cyberSport.PointsCount = request.CyberSport.PointsCount;
        cyberSport.CyberSportDate = request.CyberSport.CyberSportDate;

        await _CyberSportService.CreateOrUpdateCyberSportValidateAndThrowAsync(
            _dataContext, cyberSport, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return cyberSport.IsnCyberSport;
    }
}