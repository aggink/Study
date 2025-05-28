using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Cinema.Halls.DtoModels;

namespace Study.Lab3.Web.Features.Cinema.Halls.Queries;

/// <summary>
/// Получение списка залов
/// </summary>
public sealed class GetListHallsQuery : IRequest<HallDto[]>
{
}

public sealed class GetListHallsQueryHandler : IRequestHandler<GetListHallsQuery, HallDto[]>
{
    private readonly DataContext _dataContext;

    public GetListHallsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<HallDto[]> Handle(GetListHallsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Halls
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .Select(x => new HallDto
            {
                IsnHall = x.IsnHall,
                Name = x.Name,
                Type = (int)x.Type,
                Capacity = x.Capacity,
                RowsCount = x.RowsCount,
                SeatsPerRow = x.SeatsPerRow,
                IsActive = x.IsActive
            })
            .ToArrayAsync(cancellationToken);
    }
}