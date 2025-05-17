using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Teachers.DtoModels;

namespace Study.Lab3.Web.Features.University.Teachers.Queries;

/// <summary>
/// Получение списка учителей
/// </summary>
public sealed class GetListTeachersQuery : IRequest<TeacherDto[]>
{
}

public sealed class GetListTeachersQueryHandler : IRequestHandler<GetListTeachersQuery, TeacherDto[]>
{
    private readonly DataContext _dataContext;

    public GetListTeachersQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<TeacherDto[]> Handle(GetListTeachersQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Teachers
            .AsNoTracking()
            .Select(x => new TeacherDto
            {
                IsnTeacher = x.IsnTeacher,
                Name = x.Name,
                SurName = x.SurName,
                PatronymicName = x.PatronymicName,
                Sex = x.Sex
            })
            .OrderBy(x => x.SurName)
            .ThenBy(x => x.Name)
            .ThenBy(x => x.PatronymicName)
            .ToArrayAsync(cancellationToken);
    }
}