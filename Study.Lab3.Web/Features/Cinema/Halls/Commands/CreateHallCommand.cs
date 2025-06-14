using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Cinema;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Cinema;
using Study.Lab3.Web.Features.Cinema.Halls.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Halls.Commands;

/// <summary>
/// Создание зала
/// </summary>
public sealed class CreateHallCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные зала
    /// </summary>
    [Required]
    [FromBody]
    public CreateHallDto Hall { get; init; }
}

public sealed class CreateHallCommandHandler : IRequestHandler<CreateHallCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IHallService _hallService;

    public CreateHallCommandHandler(
        DataContext dataContext,
        IHallService hallService)
    {
        _dataContext = dataContext;
        _hallService = hallService;
    }

    public async Task<Guid> Handle(CreateHallCommand request, CancellationToken cancellationToken)
    {
        var hall = new Hall
        {
            IsnHall = Guid.NewGuid(),
            Name = request.Hall.Name,
            Type = request.Hall.Type,
            RowsCount = request.Hall.RowsCount,
            SeatsPerRow = request.Hall.SeatsPerRow,
            Capacity = request.Hall.RowsCount * request.Hall.SeatsPerRow,
            IsActive = true,
            Seats = new List<Seat>()
        };

        await _hallService.CreateOrUpdateHallValidateAndThrowAsync(
            _dataContext, hall, cancellationToken);

        await _dataContext.Halls.AddAsync(hall, cancellationToken);

        // Генерация мест в зале
        await _hallService.GenerateSeatsForHallAsync(_dataContext, hall, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return hall.IsnHall;
    }
}