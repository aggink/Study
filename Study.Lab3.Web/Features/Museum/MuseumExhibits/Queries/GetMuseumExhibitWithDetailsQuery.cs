using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Museum.MuseumExhibits.DtoModels;

namespace Study.Lab3.Web.Features.Museum.MuseumExhibits.Queries;

/// <summary>
/// Получить экспонат с детальной информацией
/// </summary>
public sealed class GetMuseumExhibitWithDetailsQuery : IRequest<MuseumExhibitWithDetailsDto>
{
    /// <summary>
    /// Идентификатор экспоната
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnMuseumExhibit { get; init; }
}

public sealed class GetMuseumExhibitWithDetailsQueryHandler : IRequestHandler<GetMuseumExhibitWithDetailsQuery, MuseumExhibitWithDetailsDto>
{
    private readonly DataContext _dataContext;

    public GetMuseumExhibitWithDetailsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MuseumExhibitWithDetailsDto> Handle(GetMuseumExhibitWithDetailsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.MuseumExhibits
            .AsNoTracking()
            .Where(x => x.IsnMuseumExhibit == request.IsnMuseumExhibit)
            .Select(x => new MuseumExhibitWithDetailsDto
            {
                IsnMuseumExhibit = x.IsnMuseumExhibit,
                Name = x.Name,
                Description = x.Description,
                AcquisitionDate = x.AcquisitionDate,
                EstimatedValue = x.EstimatedValue,
                Location = x.Location,
                Status = x.Status,
                Details = x.Details != null ? new MuseumExhibitDetailsDto
                {
                    IsnMuseumExhibitDetails = x.Details.IsnMuseumExhibitDetails,
                    IsnMuseumExhibit = x.Details.IsnMuseumExhibit,
                    Origin = x.Details.Origin,
                    Creator = x.Details.Creator,
                    CreationYear = x.Details.CreationYear,
                    Material = x.Details.Material,
                    Dimensions = x.Details.Dimensions,
                    Weight = x.Details.Weight,
                    HistoricalPeriod = x.Details.HistoricalPeriod,
                    Condition = x.Details.Condition
                } : null
            })
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new BusinessLogicException($"Экспонат с идентификатором \"{request.IsnMuseumExhibit}\" не существует");
    }
}