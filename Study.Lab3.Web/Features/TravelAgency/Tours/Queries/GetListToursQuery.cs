using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.TravelAgency.Tours.DtoModels;

namespace Study.Lab3.Web.Features.TravelAgency.Tours.Queries;

/// <summary>
/// Получение списка туров
/// </summary>
public sealed class GetListToursQuery : IRequest<TourDto[]>
{
    /// <summary>
    /// Фильтр по стране (опционально)
    /// </summary>
    [FromQuery]
    public string Country { get; init; }

    /// <summary>
    /// Фильтр по городу (опционально)
    /// </summary>
    [FromQuery]
    public string City { get; init; }

    /// <summary>
    /// Показывать только доступные туры
    /// </summary>
    [FromQuery]
    public bool? OnlyAvailable { get; init; }

    /// <summary>
    /// Минимальная цена
    /// </summary>
    [FromQuery]
    public decimal? MinPrice { get; init; }

    /// <summary>
    /// Максимальная цена
    /// </summary>
    [FromQuery]
    public decimal? MaxPrice { get; init; }
}

public sealed class GetListToursQueryHandler : IRequestHandler<GetListToursQuery, TourDto[]>
{
    private readonly DataContext _dataContext;

    public GetListToursQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<TourDto[]> Handle(GetListToursQuery request, CancellationToken cancellationToken)
    {
        var query = _dataContext.Tours.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Country))
            query = query.Where(x => x.Country.Contains(request.Country));

        if (!string.IsNullOrWhiteSpace(request.City))
            query = query.Where(x => x.City.Contains(request.City));

        if (request.OnlyAvailable == true)
            query = query.Where(x => x.IsAvailable);

        if (request.MinPrice.HasValue)
            query = query.Where(x => x.Price >= request.MinPrice.Value);

        if (request.MaxPrice.HasValue)
            query = query.Where(x => x.Price <= request.MaxPrice.Value);

        return await query
            .Select(x => new TourDto
            {
                IsnTour = x.IsnTour,
                Name = x.Name,
                Description = x.Description,
                Country = x.Country,
                City = x.City,
                Price = x.Price,
                Duration = x.Duration,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                MaxParticipants = x.MaxParticipants,
                IsAvailable = x.IsAvailable
            })
            .OrderBy(x => x.StartDate)
            .ToArrayAsync(cancellationToken);
    }
}