using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.TheKvn.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheKvn.Queries;

/// <summary>
/// Получить количество участников по идентификатору
/// </summary>
public sealed class GetKvnByIsnQuery : IRequest<KvnDto>
{
    /// <summary>
    /// Идентификатор количества участников
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnKvn { get; init; }
}

public sealed class GetKvnByIsnQueryHandler : IRequestHandler<GetKvnByIsnQuery, KvnDto>
{
    private readonly DataContext _dataContext;

    public GetKvnByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<KvnDto> Handle(GetKvnByIsnQuery request, CancellationToken cancellationToken)
    {
        var kvn = await _dataContext.TheKvn
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnKvn == request.IsnKvn, cancellationToken)
                ?? throw new BusinessLogicException($"Количества участников с идентификатором \"{request.IsnKvn}\" не существует");

        return new KvnDto
        {
            IsnKvn = kvn.IsnKvn,
            IsnStudent = kvn.IsnStudent,
            IsnSubject = kvn.IsnSubject,
            ParticipantsCount = kvn.ParticipantsCount,
            KvnDate = kvn.KvnDate
        };
    }
}