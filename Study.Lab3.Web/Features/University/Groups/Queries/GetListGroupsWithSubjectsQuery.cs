using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Groups.DtoModels;

namespace Study.Lab3.Web.Features.University.Groups.Queries;
//Запрос на получение списка групп с предметами
/// <summary>
/// Получить группу с предметами
/// </summary>
public sealed class GetListGroupsWithSubjectsQuery : IRequest<GroupWithSubjectItemDto[]>
{
    //
}

public sealed class GetListGroupsWithSubjectsQueryHandler : IRequestHandler<GetListGroupsWithSubjectsQuery, GroupWithSubjectItemDto[]>
{
    private readonly DataContext _dataContext;

    public GetListGroupsWithSubjectsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<GroupWithSubjectItemDto[]> Handle(GetListGroupsWithSubjectsQuery request, CancellationToken cancellationToken)
    {
        var groups = await _dataContext.Groups
            .Select(group => new GroupWithSubjectItemDto
            {
                IsnGroup = group.IsnGroup,
                Name = group.Name,
                Subjects = group.SubjectGroups
                    .Select(subject => new SubjectItemDto
                    {
                        IsnSubject = subject.IsnSubject,
                        Name = subject.Subject.Name
                    })
                    .ToArray()
            })
            .OrderBy(x => x.Name)
            .ToArrayAsync(cancellationToken);

        return groups;
    }
}