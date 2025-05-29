using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Cinema;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Cinema.Halls.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Halls.Commands;

/// <summary>
/// Обновление зала
/// </summary>
public sealed class UpdateHallCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные зала
    /// </summary>
    [Required]
    [FromBody]
    public UpdateHallDto Hall { get; init; }
}

public sealed class UpdateHallCommandHandler : IRequestHandler<UpdateHallCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IHallService _hallService;

    public UpdateHallCommandHandler(
        DataContext dataContext,
        IHallService hallService)
    {
        _dataContext = dataContext;
        _hallService = hallService;
    }

    public async Task<Guid> Handle(UpdateHallCommand request, CancellationToken cancellationToken)
    {
        var hall = await _dataContext.Halls
                       .FirstOrDefaultAsync(x => x.IsnHall == request.Hall.IsnHall, cancellationToken)
                   ?? throw new BusinessLogicException(
                       $"Зал с идентификатором \"{request.Hall.IsnHall}\" не существует");

        hall.Name = request.Hall.Name;
        hall.Type = request.Hall.Type;
        hall.IsActive = request.Hall.IsActive;

        await _hallService.CreateOrUpdateHallValidateAndThrowAsync(
            _dataContext, hall, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return hall.IsnHall;
    }
}