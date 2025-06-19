using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.TravelAgency;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.TravelAgency.Hotels.Commands;

/// <summary>
/// Удаление отеля
/// </summary>
public sealed class DeleteHotelCommand : IRequest
{
    /// <summary>
    /// Идентификатор отеля
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnHotel { get; init; }
}

public sealed class DeleteHotelCommandHandler : IRequestHandler<DeleteHotelCommand>
{
    private readonly DataContext _dataContext;
    private readonly IHotelService _hotelService;

    public DeleteHotelCommandHandler(
        DataContext dataContext,
        IHotelService hotelService)
    {
        _dataContext = dataContext;
        _hotelService = hotelService;
    }

    public async Task Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
    {
        var hotel = await _dataContext.Hotels
                        .FirstOrDefaultAsync(x => x.IsnHotel == request.IsnHotel, cancellationToken)
                    ?? throw new BusinessLogicException($"Отель с идентификатором \"{request.IsnHotel}\" не существует");

        await _hotelService.CanDeleteAndThrowAsync(_dataContext, hotel, cancellationToken);

        _dataContext.Hotels.Remove(hotel);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}