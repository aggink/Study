using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.TravelAgency;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.TravelAgency.Hotels.DtoModels;

namespace Study.Lab3.Web.Features.TravelAgency.Hotels.Commands;

/// <summary>
/// Обновление отеля
/// </summary>
public sealed class UpdateHotelCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные отеля
    /// </summary>
    [Required]
    [FromBody]
    public UpdateHotelDto Hotel { get; init; }
}

public sealed class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IHotelService _hotelService;

    public UpdateHotelCommandHandler(
        DataContext dataContext,
        IHotelService hotelService)
    {
        _dataContext = dataContext;
        _hotelService = hotelService;
    }

    public async Task<Guid> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
    {
        var hotel = await _dataContext.Hotels
                        .FirstOrDefaultAsync(x => x.IsnHotel == request.Hotel.IsnHotel, cancellationToken)
                    ?? throw new BusinessLogicException($"Отель с идентификатором \"{request.Hotel.IsnHotel}\" не существует");

        hotel.Name = request.Hotel.Name;
        hotel.Description = request.Hotel.Description;
        hotel.Address = request.Hotel.Address;
        hotel.Country = request.Hotel.Country;
        hotel.City = request.Hotel.City;
        hotel.StarRating = request.Hotel.StarRating;
        hotel.PricePerNight = request.Hotel.PricePerNight;
        hotel.HasWiFi = request.Hotel.HasWiFi;
        hotel.HasPool = request.Hotel.HasPool;
        hotel.HasSpa = request.Hotel.HasSpa;
        hotel.Phone = request.Hotel.Phone;
        hotel.Email = request.Hotel.Email;

        await _hotelService.CreateOrUpdateHotelValidateAndThrowAsync(
            _dataContext, hotel, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return hotel.IsnHotel;
    }
}