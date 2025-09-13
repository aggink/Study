using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.PoliceDepartament.Intern.DtoModels;

namespace Study.Lab3.Web.Features.PoliceDepartament.Intern.Queries;

public sealed class GetListInternsQuery : IRequest<InternDto[]>
{

}
public sealed class GetListInternsQueryHandler : IRequestHandler<GetListInternsQuery, InternDto[]>
{
    private readonly DataContext _dataContext;
    public GetListInternsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<InternDto[]> Handle(GetListInternsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Interns
        .AsNoTracking()
        .Select(x => new InternDto
        {
            IsnIntern = x.IsnIntern,
            Name = x.Name,
            SurName = x.SurName,
            SkillLevel = x.SkillLevel
        })
        .ToArrayAsync(cancellationToken);
    }
}

