using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Museum;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Museum.MuseumExhibits.DtoModels;

namespace Study.Lab3.Web.Features.Museum.MuseumExhibits.Command;

/// <summary>
/// Обновление экспоната музея
/// </summary>
public sealed class UpdateMuseumExhibitCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные экспоната
    /// </summary>
    [Required]
    [FromBody]
    public UpdateMuseumExhibitDto Exhibit { get; init; }
}

public sealed class UpdateMuseumExhibitCommandHandler : IRequestHandler<UpdateMuseumExhibitCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IMuseumExhibitService _exhibitService;

    public UpdateMuseumExhibitCommandHandler(
        DataContext dataContext,
        IMuseumExhibitService exhibitService)
    {
        _dataContext = dataContext;
        _exhibitService = exhibitService;
    }

    public async Task<Guid> Handle(UpdateMuseumExhibitCommand request, CancellationToken cancellationToken)
    {
        var exhibit = await _dataContext.MuseumExhibits
                          .FirstOrDefaultAsync(x => x.IsnMuseumExhibit == request.Exhibit.IsnMuseumExhibit, cancellationToken)
                      ?? throw new BusinessLogicException($"Экспонат с идентификатором \"{request.Exhibit.IsnMuseumExhibit}\" не существует");

        exhibit.Name = request.Exhibit.Name;
        exhibit.Description = request.Exhibit.Description;
        exhibit.AcquisitionDate = request.Exhibit.AcquisitionDate;
        exhibit.EstimatedValue = request.Exhibit.EstimatedValue;
        exhibit.Location = request.Exhibit.Location;
        exhibit.Status = request.Exhibit.Status;

        await _exhibitService.CreateOrUpdateExhibitValidateAndThrowAsync(
            _dataContext, exhibit, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return exhibit.IsnMuseumExhibit;
    }
}