using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.TheKvn.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheKvn.Queries;

/// <summary>
/// Получить количество участников с деталями
/// </summary>
public sealed class GetKvnWithDetailsQuery : IRequest<KvnWithDetailsDto>
{
    /// <summary>
    /// Идентификатор количества участников
    /// </summary>
    [Required]
    public Guid IsnKvn { get; init; }
}

public sealed class GetKvnWithDetailsQueryHandler : IRequestHandler<GetKvnWithDetailsQuery, KvnWithDetailsDto>
{
    private readonly DataContext _dataContext;

    public GetKvnWithDetailsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<KvnWithDetailsDto> Handle(GetKvnWithDetailsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.TheKvn
            .AsNoTracking()
            .Where(x => x.IsnKvn == request.IsnKvn)
            .Select(kvn => new KvnWithDetailsDto
            {
                IsnKvn = kvn.IsnKvn,
                IsnStudent = kvn.IsnStudent,
                StudentFullName = $"{kvn.Student.SurName} {kvn.Student.Name} {kvn.Student.PatronymicName}",
                IsnSubject = kvn.IsnSubject,
                SubjectName = kvn.Subject.Name,
                ParticipantsCount = kvn.ParticipantsCount,
                KvnDate = kvn.KvnDate,
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
}