using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.TravelAgency;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.TravelAgency;
using Study.Lab3.Web.Features.TravelAgency.Hotels.DtoModels;

namespace Study.Lab3.Web.Features.TravelAgency.Hotels.Commands;

/// <summary>
/// Создание отеля
/// </summary>
public sealed class CreateHotelCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные отеля
    /// </summary>
    [Required]
    [FromBody]
    public CreateHotelDto Hotel { get; init; }
}

public sealed class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IHotelService _hotelService;

    public CreateHotelCommandHandler(
        DataContext dataContext,
        IHotelService hotelService)
    {
        _dataContext = dataContext;
        _hotelService = hotelService;
    }

    public async Task<Guid> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
    {
        var hotel = new Hotel
        {
            IsnHotel = Guid.NewGuid(),
            Name = request.Hotel.Name,
            Description = request.Hotel.Description,
            Address = request.Hotel.Address,
            Country = request.Hotel.Country,
            City = request.Hotel.City,
            StarRating = request.Hotel.StarRating,
            PricePerNight = request.Hotel.PricePerNight,
            HasWiFi = request.Hotel.HasWiFi,
            HasPool = request.Hotel.HasPool,
            HasSpa = request.Hotel.HasSpa,
            Phone = request.Hotel.Phone,
            Email = request.Hotel.Email
        };

        await _hotelService.CreateOrUpdateHotelValidateAndThrowAsync(
            _dataContext, hotel, cancellationToken);

        await _dataContext.Hotels.AddAsync(hotel, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return hotel.IsnHotel;
    }
}
