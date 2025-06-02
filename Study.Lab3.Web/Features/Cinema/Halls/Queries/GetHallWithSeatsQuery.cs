using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Cinema.Halls.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Halls.Queries;

/// <summary>
/// Получение зала с местами
/// </summary>
public sealed class GetHallWithSeatsQuery : IRequest<HallWithSeatsDto>
{
    /// <summary>
    /// Идентификатор зала
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnHall { get; init; }
}

public sealed class GetHallWithSeatsQueryHandler : IRequestHandler<GetHallWithSeatsQuery, HallWithSeatsDto>
{
    private readonly DataContext _dataContext;

    public GetHallWithSeatsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<HallWithSeatsDto> Handle(GetHallWithSeatsQuery request, CancellationToken cancellationToken)
    {
        var hall = await _dataContext.Halls
                       .AsNoTracking()
                       .Include(x => x.Seats)
                       .Include(x => x.Sessions.Where(s => s.StartTime >= DateTime.UtcNow))
                       .FirstOrDefaultAsync(x => x.IsnHall == request.IsnHall, cancellationToken)
                   ?? throw new BusinessLogicException(
                       $"Зал с идентификатором \"{request.IsnHall}\" не существует");

        return new HallWithSeatsDto
        {
            IsnHall = hall.IsnHall,
            Name = hall.Name,
            Type = hall.Type,
            Capacity = hall.Capacity,
            RowsCount = hall.RowsCount,
            SeatsPerRow = hall.SeatsPerRow,
            IsActive = hall.IsActive,
            Seats = hall.Seats
                .Select(s => new SeatItemDto
                {
                    IsnSeat = s.IsnSeat,
                    Row = s.Row,
                    Number = s.Number,
                    Type = s.Type,
                    IsActive = s.IsActive
                })
                .OrderBy(s => s.Row)
                .ThenBy(s => s.Number)
                .ToArray(),
            SessionsCount = hall.Sessions.Count()
        };
    }
}