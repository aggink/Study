using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.PoliceDepartament.Officer.DtoModels;

namespace Study.Lab3.Web.Features.PoliceDepartament.Officer.Queries;

public sealed class GetListOfficersQuery : IRequest<OfficerDto[]>
{

}
public sealed class GetListOfficersQueryHandler : IRequestHandler<GetListOfficersQuery, OfficerDto[]>
{
    private readonly DataContext _dataContext;
    public GetListOfficersQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<OfficerDto[]> Handle(GetListOfficersQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Officers
        .AsNoTracking()
        .Select(x => new OfficerDto
        {
            IsnOfficer = x.IsnOfficer,
            Name = x.Name,
            SurName = x.SurName,
            Rank = x.Rank
        })
        .ToArrayAsync(cancellationToken);
    }
}
