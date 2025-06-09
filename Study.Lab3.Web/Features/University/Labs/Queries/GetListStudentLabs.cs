using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Labs.DtoModels;

namespace Study.Lab3.Web.Features.University.Labs.Queries;

/// <summary>
/// Получение списка групп
/// </summary>
public sealed class GetListStudentLabQuery : IRequest<StudentLabItemDto[]>
{

}

public sealed class GetListStudentLabQueryHandler : IRequestHandler<GetListStudentLabQuery, StudentLabItemDto[]>
{
    private readonly DataContext _dataContext;

    public GetListStudentLabQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<StudentLabItemDto[]> Handle(GetListStudentLabQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.StudentLab
            .AsNoTracking()
            .Select(x => new StudentLabItemDto
            {
                IsnLab = x.IsnLab,
                IsnStudent = x.IsnStudent,
                IsnStudentLab = x.IsnStudentLab,
                Value = x.Value
            })
            .OrderBy(x => x.Value)
            .ToArrayAsync(cancellationToken);
    }
}
