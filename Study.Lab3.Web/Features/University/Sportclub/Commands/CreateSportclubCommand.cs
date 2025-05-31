using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Web.Features.University.TheSportclub.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheSportclub.Commands;

/// <summary>
/// Создание спортивного клуба
/// </summary>
public sealed class CreateSportclubCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные спортивного клуба
    /// </summary>
    [Required]
    [FromBody]
    public CreateSportclubDto Sportclub { get; init; }
}

public sealed class CreateSportclubCommandHandler : IRequestHandler<CreateSportclubCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly ISportclubService _sportclubService;

    public CreateSportclubCommandHandler(
        DataContext dataContext,
        ISportclubService sportclubService)
    {
        _dataContext = dataContext;
        _sportclubService = sportclubService;
    }

    public async Task<Guid> Handle(CreateSportclubCommand request, CancellationToken cancellationToken)
    {
        var sportclub = new Sportclub
        {
            IsnSportclub = Guid.NewGuid(),
            IsnStudent = request.Sportclub.IsnStudent,
            IsnSubject = request.Sportclub.IsnSubject,
            ParticipantsCount = request.Sportclub.ParticipantsCount,
            SportclubDate = request.Sportclub.SportclubDate
        };

        await _sportclubService.CreateOrUpdateSportclubValidateAndThrowAsync(
            _dataContext, sportclub, cancellationToken);

        await _dataContext.Sportclub.AddAsync(sportclub, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return sportclub.IsnSportclub;
    }
}