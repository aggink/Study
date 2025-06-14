using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Enums.TravelAgency;
using Study.Lab3.Web.Features.TravelAgency.Hotels.DtoModels;

namespace Study.Lab3.Web.Features.TravelAgency.Hotels.Queries;

/// <summary>
/// Получение списка отелей
/// </summary>
public sealed class GetListHotelsQuery : IRequest<HotelDto[]>
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
    /// Минимальное количество звезд
    /// </summary>
    [FromQuery]
    public HotelStarRating? MinStarRating { get; init; }

    /// <summary>
    /// Минимальная цена за ночь
    /// </summary>
    [FromQuery]
    public decimal? MinPrice { get; init; }

    /// <summary>
    /// Максимальная цена за ночь
    /// </summary>
    [FromQuery]
    public decimal? MaxPrice { get; init; }

    /// <summary>
    /// Должен ли быть Wi-Fi
    /// </summary>
    [FromQuery]
    public bool? HasWiFi { get; init; }

    /// <summary>
    /// Должен ли быть бассейн
    /// </summary>
    [FromQuery]
    public bool? HasPool { get; init; }

    /// <summary>
    /// Должно ли быть спа
    /// </summary>
    [FromQuery]
    public bool? HasSpa { get; init; }
}

public sealed class GetListHotelsQueryHandler : IRequestHandler<GetListHotelsQuery, HotelDto[]>
{
    private readonly DataContext _dataContext;

    public GetListHotelsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<HotelDto[]> Handle(GetListHotelsQuery request, CancellationToken cancellationToken)
    {
        var query = _dataContext.Hotels.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Country))
            query = query.Where(x => x.Country.Contains(request.Country));

        if (!string.IsNullOrWhiteSpace(request.City))
            query = query.Where(x => x.City.Contains(request.City));

        if (request.MinStarRating.HasValue)
            query = query.Where(x => x.StarRating >= request.MinStarRating.Value);

        if (request.MinPrice.HasValue)
            query = query.Where(x => x.PricePerNight >= request.MinPrice.Value);

        if (request.MaxPrice.HasValue)
            query = query.Where(x => x.PricePerNight <= request.MaxPrice.Value);

        if (request.HasWiFi == true)
            query = query.Where(x => x.HasWiFi);

        if (request.HasPool == true)
            query = query.Where(x => x.HasPool);

        if (request.HasSpa == true)
            query = query.Where(x => x.HasSpa);

        return await query
            .Select(x => new HotelDto
            {
                IsnHotel = x.IsnHotel,
                Name = x.Name,
                Description = x.Description,
                Address = x.Address,
                Country = x.Country,
                City = x.City,
                StarRating = x.StarRating,
                PricePerNight = x.PricePerNight,
                HasWiFi = x.HasWiFi,
                HasPool = x.HasPool,
                HasSpa = x.HasSpa,
                Phone = x.Phone,
                Email = x.Email
            })
            .OrderBy(x => x.Country)
            .ThenBy(x => x.City)
            .ThenBy(x => x.Name)
            .ToArrayAsync(cancellationToken);
    }
}