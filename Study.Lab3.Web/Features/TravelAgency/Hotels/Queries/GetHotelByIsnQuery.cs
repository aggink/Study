using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.TravelAgency.Hotels.DtoModels;

namespace Study.Lab3.Web.Features.TravelAgency.Hotels.Queries;

/// <summary>
/// Получить отель по идентификатору
/// </summary>
public sealed class GetHotelByIsnQuery : IRequest<HotelDto>
{
    /// <summary>
    /// Идентификатор отеля
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnHotel { get; init; }
}

public sealed class GetHotelByIsnQueryHandler : IRequestHandler<GetHotelByIsnQuery, HotelDto>
{
    private readonly DataContext _dataContext;

    public GetHotelByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<HotelDto> Handle(GetHotelByIsnQuery request, CancellationToken cancellationToken)
    {
        var hotel = await _dataContext.Hotels
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.IsnHotel == request.IsnHotel, cancellationToken)
                    ?? throw new BusinessLogicException($"Отель с идентификатором \"{request.IsnHotel}\" не существует");

        return new HotelDto
        {
            IsnHotel = hotel.IsnHotel,
            Name = hotel.Name,
            Description = hotel.Description,
            Address = hotel.Address,
            Country = hotel.Country,
            City = hotel.City,
            StarRating = hotel.StarRating,
            PricePerNight = hotel.PricePerNight,
            HasWiFi = hotel.HasWiFi,
            HasPool = hotel.HasPool,
            HasSpa = hotel.HasSpa,
            Phone = hotel.Phone,
            Email = hotel.Email
        };
    }
}
