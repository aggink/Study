using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Cinema;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Enums.Cinema;
using Study.Lab3.Storage.Models.Cinema;

namespace Study.Lab3.Logic.Services.Cinema;

public sealed class HallService : IHallService
{
    public async Task CreateOrUpdateHallValidateAndThrowAsync(
        DataContext dataContext,
        Hall hall,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(hall.Name))
            throw new BusinessLogicException("Название зала не может быть пустым");

        // Проверка корректности вместимости
        var calculatedCapacity = hall.RowsCount * hall.SeatsPerRow;
        if (hall.Capacity != calculatedCapacity)
        {
            hall.Capacity = calculatedCapacity;
        }

        // Проверка на дубликат названия
        if (await dataContext.Halls.AnyAsync(
            x => x.Name == hall.Name && x.IsnHall != hall.IsnHall,
            cancellationToken))
        {
            throw new BusinessLogicException($"Зал с названием \"{hall.Name}\" уже существует");
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Hall hall,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Halls.AnyAsync(x => x.IsnHall == hall.IsnHall, cancellationToken))
            throw new BusinessLogicException(
                $"Зал с идентификатором \"{hall.IsnHall}\" не существует");

        // Проверка на наличие будущих сеансов
        var hasFutureSessions = await dataContext.Sessions
            .AnyAsync(x => x.IsnHall == hall.IsnHall &&
                          x.StartTime > DateTime.UtcNow,
                      cancellationToken);

        if (hasFutureSessions)
            throw new BusinessLogicException(
                "Невозможно удалить зал, так как в нем запланированы сеансы");
    }

    public async Task GenerateSeatsForHallAsync(
        DataContext dataContext,
        Hall hall,
        CancellationToken cancellationToken = default)
    {
        // Удаляем старые места, если они есть
        var existingSeats = await dataContext.Seats
            .Where(x => x.IsnHall == hall.IsnHall)
            .ToListAsync(cancellationToken);

        if (existingSeats.Any())
        {
            dataContext.Seats.RemoveRange(existingSeats);
        }

        // Генерируем новые места
        var seats = new List<Seat>();
        var vipRows = hall.Type == HallType.VIP ? hall.RowsCount : 2; // В VIP зале все места VIP, иначе только первые 2 ряда

        for (int row = 1; row <= hall.RowsCount; row++)
        {
            for (int number = 1; number <= hall.SeatsPerRow; number++)
            {
                var seatType = row <= vipRows ? SeatType.VIP : SeatType.Standard;

                // Каждое 10-е место для инвалидов
                if (number % 10 == 0)
                {
                    seatType = SeatType.Wheelchair;
                }
                // Парные места в последних рядах
                else if (row >= hall.RowsCount - 1 && number % 2 == 0)
                {
                    seatType = SeatType.Couple;
                }

                var seat = new Seat
                {
                    IsnSeat = Guid.NewGuid(),
                    IsnHall = hall.IsnHall,
                    Row = row,
                    Number = number,
                    Type = seatType,
                    IsActive = true
                };

                seats.Add(seat);
            }
        }

        await dataContext.Seats.AddRangeAsync(seats, cancellationToken);
    }
}