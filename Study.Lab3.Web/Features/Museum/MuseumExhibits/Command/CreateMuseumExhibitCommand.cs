using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Museum;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Museum;
using Study.Lab3.Web.Features.Museum.MuseumExhibits.DtoModels;

namespace Study.Lab3.Web.Features.Museum.MuseumExhibits.Command;

/// <summary>
/// Создание экспоната музея
/// </summary>
public sealed class CreateMuseumExhibitCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные экспоната
    /// </summary>
    [Required]
    [FromBody]
    public CreateMuseumExhibitDto Exhibit { get; init; }
}

public sealed class CreateMuseumExhibitCommandHandler : IRequestHandler<CreateMuseumExhibitCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IMuseumExhibitService _exhibitService;

    public CreateMuseumExhibitCommandHandler(
        DataContext dataContext,
        IMuseumExhibitService exhibitService)
    {
        _dataContext = dataContext;
        _exhibitService = exhibitService;
    }

    public async Task<Guid> Handle(CreateMuseumExhibitCommand request, CancellationToken cancellationToken)
    {
        var exhibit = new MuseumExhibit
        {
            IsnMuseumExhibit = Guid.NewGuid(),
            Name = request.Exhibit.Name,
            Description = request.Exhibit.Description,
            AcquisitionDate = request.Exhibit.AcquisitionDate,
            EstimatedValue = request.Exhibit.EstimatedValue,
            Location = request.Exhibit.Location,
            Status = request.Exhibit.Status
        };

        await _exhibitService.CreateOrUpdateExhibitValidateAndThrowAsync(
            _dataContext, exhibit, cancellationToken);

        await _dataContext.MuseumExhibits.AddAsync(exhibit, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return exhibit.IsnMuseumExhibit;
    }
}