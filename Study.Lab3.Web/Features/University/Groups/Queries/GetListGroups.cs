using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Groups.DtoModels;

namespace Study.Lab3.Web.Features.University.Groups.Queries;
//Запрос на получение списка групп студентов
/// <summary>
/// Получение списка групп
/// </summary>
public sealed class GetListGroupsQuery : IRequest<GroupItemDto[]>
{

}

public sealed class GetListGroupsQueryHandler : IRequestHandler<GetListGroupsQuery, GroupItemDto[]>
{
    private readonly DataContext _dataContext;

    public GetListGroupsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<GroupItemDto[]> Handle(GetListGroupsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Groups
            .AsNoTracking()
            .Select(x => new GroupItemDto
            {
                IsnGroup = x.IsnGroup,
                Name = x.Name
            })
            .OrderBy(x => x.Name)
            .ToArrayAsync(cancellationToken);
    }
}
