using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Cinema.Halls.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Halls.Queries;

/// <summary>
/// Получение зала по идентификатору
/// </summary>
public sealed class GetHallByIdQuery : IRequest<HallDto>
{
    /// <summary>
    /// Идентификатор зала
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnHall { get; init; }
}

public sealed class GetHallByIdQueryHandler : IRequestHandler<GetHallByIdQuery, HallDto>
{
    private readonly DataContext _dataContext;

    public GetHallByIdQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<HallDto> Handle(GetHallByIdQuery request, CancellationToken cancellationToken)
    {
        var hall = await _dataContext.Halls
                       .AsNoTracking()
                       .FirstOrDefaultAsync(x => x.IsnHall == request.IsnHall, cancellationToken)
                   ?? throw new BusinessLogicException(
                       $"Зал с идентификатором \"{request.IsnHall}\" не существует");

        return new HallDto
        {
            IsnHall = hall.IsnHall,
            Name = hall.Name,
            Type = (int)hall.Type,
            Capacity = hall.Capacity,
            RowsCount = hall.RowsCount,
            SeatsPerRow = hall.SeatsPerRow,
            IsActive = hall.IsActive
        };
    }
}