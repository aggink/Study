using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Exams.DtoModels;

namespace Study.Lab3.Web.Features.University.Exams.Queries;

/// <summary>
/// Получение списка экзаменов
/// </summary>
public sealed class GetListExamsQuery : IRequest<ExamDto[]>
{
}

public sealed class GetListExamsQueryHandler : IRequestHandler<GetListExamsQuery, ExamDto[]>
{
    private readonly DataContext _dataContext;

    public GetListExamsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ExamDto[]> Handle(GetListExamsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Exams
            .AsNoTracking()
            .Select(x => new ExamDto
            {
                IsnExam = x.IsnExam,
                IsnSubject = x.IsnSubject,
                Name = x.Name,
                Description = x.Description,
                ExamDate = x.ExamDate,
                Duration = x.Duration,
                MaxScore = x.MaxScore,
                PassingScore = x.PassingScore
            })
            .OrderBy(x => x.ExamDate)
            .ToArrayAsync(cancellationToken);
    }
}