using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Groups.DtoModels;

namespace Study.Lab3.Web.Features.University.Groups.Queries;

/// <summary>
/// Получение списка групп
/// </summary>
public sealed class GetListGroupsQuery : IRequest<GroupDto[]>
{

}

public sealed class GetListGroupsQueryHandler : IRequestHandler<GetListGroupsQuery, GroupDto[]>
{
    private readonly DataContext _dataContext;

    public GetListGroupsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<GroupDto[]> Handle(GetListGroupsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Groups
            .AsNoTracking()
            .Select(x => new GroupDto
            {
                IsnGroup = x.IsnGroup,
                Name = x.Name
            })
            .ToArrayAsync(cancellationToken);
    }
}
