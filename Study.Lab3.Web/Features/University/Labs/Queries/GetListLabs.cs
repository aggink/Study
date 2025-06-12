using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Labs.DtoModels;

namespace Study.Lab3.Web.Features.University.Labs.Queries;

/// <summary>
/// Получение списка групп
/// </summary>
public sealed class GetListLabsQuery : IRequest<LabItemDto[]>
{

}

public sealed class GetListLabsQueryHandler : IRequestHandler<GetListLabsQuery, LabItemDto[]>
{
    private readonly DataContext _dataContext;

    public GetListLabsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<LabItemDto[]> Handle(GetListLabsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Labs
            .AsNoTracking()
            .Select(x => new LabItemDto
            {
                IsnLab = x.IsnLab,
                Name = x.Name
            })
            .OrderBy(x => x.Name)
            .ToArrayAsync(cancellationToken);
    }
}
