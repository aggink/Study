using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.ExamResults.DtoModels;

namespace Study.Lab3.Web.Features.University.ExamResults.Queries;

/// <summary>
/// Получение списка результатов экзаменов
/// </summary>
public sealed class GetListExamResultsQuery : IRequest<ExamResultDto[]>
{
}

public sealed class GetListExamResultsQueryHandler : IRequestHandler<GetListExamResultsQuery, ExamResultDto[]>
{
    private readonly DataContext _dataContext;

    public GetListExamResultsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ExamResultDto[]> Handle(GetListExamResultsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.ExamResults
            .AsNoTracking()
            .Select(x => new ExamResultDto
            {
                IsnExamResult = x.IsnExamResult,
                IsnExamRegistration = x.IsnExamRegistration,
                Score = x.Score,
                IsPassed = x.IsPassed,
                Comments = x.Comments
            })
            .ToArrayAsync(cancellationToken);
    }
}