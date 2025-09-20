using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.CyberSport.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.CyberSport.Commands;

/// <summary>
/// Создание киберспорта
/// </summary>
public sealed class CreateCyberSportCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные киберспорта
    /// </summary>
    [Required]
    [FromBody]
    public CreateCyberSportDto CyberSport { get; init; }
}

public sealed class CreateSportCommandHandler : IRequestHandler<CreateCyberSportCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly ICyberSportService _cyberSportService;

    public CreateSportCommandHandler(
        DataContext dataContext,
        ICyberSportService cyberSportService)
    {
        _dataContext = dataContext;
        _cyberSportService = cyberSportService;
    }

    public async Task<Guid> Handle(CreateCyberSportCommand request, CancellationToken cancellationToken)
    {
        var cyberSport = new Storage.Models.University.CyberSport
        {
            IsnCyberSport = Guid.NewGuid(),
            IsnStudent = request.CyberSport.IsnStudent,
            IsnSubject = request.CyberSport.IsnSubject,
            PointsCount = request.CyberSport.PointsCount,
            CyberSportDate = request.CyberSport.CyberSportDate
        };

        await _cyberSportService.CreateOrUpdateCyberSportValidateAndThrowAsync(
            _dataContext, cyberSport, cancellationToken);

        await _dataContext.CyberSport.AddAsync(cyberSport, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return cyberSport.IsnCyberSport;
    }
}