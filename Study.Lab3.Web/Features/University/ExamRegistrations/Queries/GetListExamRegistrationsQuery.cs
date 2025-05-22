using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.ExamRegistrations.DtoModels;

namespace Study.Lab3.Web.Features.University.ExamRegistrations.Queries;

/// <summary>
/// Получение списка регистраций на экзамены
/// </summary>
public sealed class GetListExamRegistrationsQuery : IRequest<ExamRegistrationDto[]>
{
}

public sealed class GetListExamRegistrationsQueryHandler : IRequestHandler<GetListExamRegistrationsQuery, ExamRegistrationDto[]>
{
    private readonly DataContext _dataContext;

    public GetListExamRegistrationsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ExamRegistrationDto[]> Handle(GetListExamRegistrationsQuery request, CancellationToken cancellationToken)
    {
        var examRegistrations = await _dataContext.ExamRegistrations
            .AsNoTracking()
            .OrderByDescending(x => x.RegistrationDate)
            .ToArrayAsync(cancellationToken);

        return examRegistrations.Select(x => new ExamRegistrationDto
        {
            IsnExamRegistration = x.IsnExamRegistration,
            IsnExam = x.IsnExam,
            IsnStudent = x.IsnStudent,
            RegistrationDate = x.RegistrationDate,
            Status = x.Status
        }).ToArray();
    }
}