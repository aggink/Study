using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Museum.MuseumExhibits.DtoModels;

namespace Study.Lab3.Web.Features.Museum.MuseumExhibits.Queries;

/// <summary>
/// Получить экспонат по идентификатору
/// </summary>
public sealed class GetMuseumExhibitByIsnQuery : IRequest<MuseumExhibitDto>
{
    /// <summary>
    /// Идентификатор экспоната
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnMuseumExhibit { get; init; }
}

public sealed class GetMuseumExhibitByIsnQueryHandler : IRequestHandler<GetMuseumExhibitByIsnQuery, MuseumExhibitDto>
{
    private readonly DataContext _dataContext;

    public GetMuseumExhibitByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MuseumExhibitDto> Handle(GetMuseumExhibitByIsnQuery request, CancellationToken cancellationToken)
    {
        var exhibit = await _dataContext.MuseumExhibits
                          .AsNoTracking()
                          .FirstOrDefaultAsync(x => x.IsnMuseumExhibit == request.IsnMuseumExhibit, cancellationToken)
                      ?? throw new BusinessLogicException($"Экспонат с идентификатором \"{request.IsnMuseumExhibit}\" не существует");

        return new MuseumExhibitDto
        {
            IsnMuseumExhibit = exhibit.IsnMuseumExhibit,
            Name = exhibit.Name,
            Description = exhibit.Description,
            AcquisitionDate = exhibit.AcquisitionDate,
            EstimatedValue = exhibit.EstimatedValue,
            Location = exhibit.Location,
            Status = exhibit.Status
        };
    }
}