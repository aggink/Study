using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Cinema;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Halls.Commands;

/// <summary>
/// Удаление зала
/// </summary>
public sealed class DeleteHallCommand : IRequest
{
    /// <summary>
    /// Идентификатор зала
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnHall { get; init; }
}

public sealed class DeleteHallCommandHandler : IRequestHandler<DeleteHallCommand>
{
    private readonly DataContext _dataContext;
    private readonly IHallService _hallService;

    public DeleteHallCommandHandler(
        DataContext dataContext,
        IHallService hallService)
    {
        _dataContext = dataContext;
        _hallService = hallService;
    }

    public async Task Handle(DeleteHallCommand request, CancellationToken cancellationToken)
    {
        var hall = await _dataContext.Halls
                       .Include(x => x.Seats)
                       .FirstOrDefaultAsync(x => x.IsnHall == request.IsnHall, cancellationToken)
                   ?? throw new BusinessLogicException(
                       $"Зал с идентификатором \"{request.IsnHall}\" не существует");

        await _hallService.CanDeleteAndThrowAsync(
            _dataContext, hall, cancellationToken);

        // Удаляем места
        _dataContext.Seats.RemoveRange(hall.Seats);

        // Удаляем зал
        _dataContext.Halls.Remove(hall);

        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}