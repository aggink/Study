using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.TheSportclub.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheSportclub.Commands;

/// <summary>
/// Редактирование спортивного клуба
/// </summary>
public sealed class UpdateSportclubCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные спортивного клуба
    /// </summary>
    [Required]
    [FromBody]
    public UpdateSportclubDto Sportclub { get; init; }
}

public sealed class UpdateSportclubCommandHandler : IRequestHandler<UpdateSportclubCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly ISportclubService _sportclubService;

    public UpdateSportclubCommandHandler(
        DataContext dataContext,
        ISportclubService sportclubService)
    {
        _dataContext = dataContext;
        _sportclubService = sportclubService;
    }

    public async Task<Guid> Handle(UpdateSportclubCommand request, CancellationToken cancellationToken)
    {
        var sportclub = await _dataContext.Sportclub
            .Include(x => x.Subject)
            .FirstOrDefaultAsync(x => x.IsnSportclub == request.Sportclub.IsnSportclub, cancellationToken)
                ?? throw new BusinessLogicException($"Соревнований с идентификатором \"{request.Sportclub.IsnSportclub}\" не существует");

        sportclub.ParticipantsCount = request.Sportclub.ParticipantsCount;
        sportclub.SportclubDate = request.Sportclub.SportclubDate;

        await _sportclubService.CreateOrUpdateSportclubValidateAndThrowAsync(
            _dataContext, sportclub, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return sportclub.IsnSportclub;
    }
}