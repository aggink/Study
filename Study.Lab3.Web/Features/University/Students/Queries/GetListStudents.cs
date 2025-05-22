using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Extensions.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Students.DtoModels;

namespace Study.Lab3.Web.Features.University.Students.Queries;

/// <summary>
/// Получить список студентов
/// </summary>
public class GetListStudentsQuery : IRequest<StudentItemDto[]>
{

}

public class GetListStudentsQueryHandler : IRequestHandler<GetListStudentsQuery, StudentItemDto[]>
{
    private readonly DataContext _dataContext;

    public GetListStudentsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<StudentItemDto[]> Handle(GetListStudentsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Students
            .AsNoTracking()
            .OrderBy(x => x.SurName)
                .ThenBy(x => x.Name)
                    .ThenBy(x => x.PatronymicName)
            .Select(x => new StudentItemDto
            {
                IsnStudent = x.IsnStudent,
                GroupName = x.Group.Name,
                Fio = x.GetFio(),
                Sex = x.Sex,
                Age = x.Age
            })
            .ToArrayAsync(cancellationToken);
    }
}
