using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Museum.MuseumExhibits.DtoModels;

namespace Study.Lab3.Web.Features.Museum.MuseumExhibits.Queries;

/// <summary>
/// Получение списка экспонатов
/// </summary>
public sealed class GetListMuseumExhibitsQuery : IRequest<MuseumExhibitDto[]>
{
}

public sealed class GetListMuseumExhibitsQueryHandler : IRequestHandler<GetListMuseumExhibitsQuery, MuseumExhibitDto[]>
{
    private readonly DataContext _dataContext;

    public GetListMuseumExhibitsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MuseumExhibitDto[]> Handle(GetListMuseumExhibitsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.MuseumExhibits
            .AsNoTracking()
            .Select(x => new MuseumExhibitDto
            {
                IsnMuseumExhibit = x.IsnMuseumExhibit,
                Name = x.Name,
                Description = x.Description,
                AcquisitionDate = x.AcquisitionDate,
                EstimatedValue = x.EstimatedValue,
                Location = x.Location,
                Status = x.Status
            })
            .OrderBy(x => x.Name)
            .ToArrayAsync(cancellationToken);
    }
}