using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.TravelAgency.Tours.DtoModels;

namespace Study.Lab3.Web.Features.TravelAgency.Tours.Queries;

/// <summary>
/// Получить тур по идентификатору
/// </summary>
public sealed class GetTourByIsnQuery : IRequest<TourDto>
{
    /// <summary>
    /// Идентификатор тура
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnTour { get; init; }
}

public sealed class GetTourByIsnQueryHandler : IRequestHandler<GetTourByIsnQuery, TourDto>
{
    private readonly DataContext _dataContext;

    public GetTourByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<TourDto> Handle(GetTourByIsnQuery request, CancellationToken cancellationToken)
    {
        var tour = await _dataContext.Tours
                       .AsNoTracking()
                       .FirstOrDefaultAsync(x => x.IsnTour == request.IsnTour, cancellationToken)
                   ?? throw new BusinessLogicException($"Тур с идентификатором \"{request.IsnTour}\" не существует");

        return new TourDto
        {
            IsnTour = tour.IsnTour,
            Name = tour.Name,
            Description = tour.Description,
            Country = tour.Country,
            City = tour.City,
            Price = tour.Price,
            Duration = tour.Duration,
            StartDate = tour.StartDate,
            EndDate = tour.EndDate,
            MaxParticipants = tour.MaxParticipants,
            IsAvailable = tour.IsAvailable
        };
    }
}