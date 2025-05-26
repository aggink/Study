using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Subjects.DtoModels;

namespace Study.Lab3.Web.Features.University.Subjects.Queries;
//Запрос на получение списка предметов
/// <summary>
/// Получить список предметов
/// </summary>
public sealed class GetListSubjectsQuery : IRequest<SubjectItemDto[]>
{
    //
}

public sealed class GetListSubjectsQueryHandler : IRequestHandler<GetListSubjectsQuery, SubjectItemDto[]>
{
    private readonly DataContext _dataContext;

    public GetListSubjectsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<SubjectItemDto[]> Handle(GetListSubjectsQuery request, CancellationToken cancellationToken)
    {
        var subjects = await _dataContext.Subjects
            .AsNoTracking()
            .Select(x => new SubjectItemDto
            {
                IsnSubject = x.IsnSubject,
                Name = x.Name
            })
            .OrderBy(x => x.Name)
            .ToArrayAsync(cancellationToken);

        return subjects;
    }
}
