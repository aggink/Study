using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Museum;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Museum;
using Study.Lab3.Web.Features.Museum.MuseumExhibits.DtoModels;

namespace Study.Lab3.Web.Features.Museum.MuseumExhibits.Command;

/// <summary>
/// Создание детальной информации об экспонате
/// </summary>
public sealed class CreateMuseumExhibitDetailsCommand : IRequest<Guid>
{
    /// <summary>
    /// Детальная информация об экспонате
    /// </summary>
    [Required]
    [FromBody]
    public CreateMuseumExhibitDetailsDto Details { get; init; }
}

public sealed class CreateMuseumExhibitDetailsCommandHandler : IRequestHandler<CreateMuseumExhibitDetailsCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IMuseumExhibitService _exhibitService;

    public CreateMuseumExhibitDetailsCommandHandler(
        DataContext dataContext,
        IMuseumExhibitService exhibitService)
    {
        _dataContext = dataContext;
        _exhibitService = exhibitService;
    }

    public async Task<Guid> Handle(CreateMuseumExhibitDetailsCommand request, CancellationToken cancellationToken)
    {
        var details = new MuseumExhibitDetails
        {
            IsnMuseumExhibitDetails = Guid.NewGuid(),
            IsnMuseumExhibit = request.Details.IsnMuseumExhibit,
            Origin = request.Details.Origin,
            Creator = request.Details.Creator,
            CreationYear = request.Details.CreationYear,
            Material = request.Details.Material,
            Dimensions = request.Details.Dimensions,
            Weight = request.Details.Weight,
            HistoricalPeriod = request.Details.HistoricalPeriod,
            Condition = request.Details.Condition
        };

        await _exhibitService.CreateOrUpdateExhibitDetailsValidateAndThrowAsync(
            _dataContext, details, cancellationToken);

        await _dataContext.MuseumExhibitDetails.AddAsync(details, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return details.IsnMuseumExhibitDetails;
    }
}