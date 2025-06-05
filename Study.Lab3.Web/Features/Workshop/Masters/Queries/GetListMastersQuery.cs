using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Workshop.Masters.DtoModels;

namespace Study.Lab3.Web.Features.Workshop.Masters.Queries;

/// <summary>
/// Получение списка мастеров
/// </summary>
public sealed class GetListMastersQuery : IRequest<MasterDto[]>
{
}

public sealed class GetListMastersQueryHandler : IRequestHandler<GetListMastersQuery, MasterDto[]>
{
    private readonly DataContext _dataContext;

    public GetListMastersQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MasterDto[]> Handle(GetListMastersQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Masters
            .AsNoTracking()
            .Select(x => new MasterDto
            {
                IsnMaster = x.IsnMaster,
                Name = x.Name,
                Email = x.Email,
                Phone = x.Phone,
                Specialization = x.Specialization
            })
            .OrderBy(x => x.Name)
            .ToArrayAsync(cancellationToken);
    }
}