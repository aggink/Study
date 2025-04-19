using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Subjects.DtoModels;

namespace Study.Lab3.Web.Features.University.Subjects.Queries;

/// <summary>
/// Получить список предметов
/// </summary>
public sealed class GetListSubjectsQuery : IRequest<SubjectItem[]>
{

}

public sealed class GetListSubjectsQueryHandler : IRequestHandler<GetListSubjectsQuery, SubjectItem[]>
{
    private readonly DataContext _dataContext;

    public GetListSubjectsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<SubjectItem[]> Handle(GetListSubjectsQuery request, CancellationToken cancellationToken)
    {
        var subjects = await _dataContext.Subjects
            .AsNoTracking()
            .Select(x => new SubjectItem
            {
                IsnSubject = x.IsnSubject,
                Name = x.Name
            })
            .ToArrayAsync(cancellationToken);

        return subjects;
    }
}
