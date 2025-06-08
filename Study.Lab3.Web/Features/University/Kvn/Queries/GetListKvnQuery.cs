using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
<<<<<<< HEAD
using Study.Lab3.Web.Features.University.TheKvn.DtoModels;

namespace Study.Lab3.Web.Features.University.TheKvn.Queries;
=======
using Study.Lab3.Web.Features.University.Kvn.DtoModels;

namespace Study.Lab3.Web.Features.University.Kvn.Queries;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

/// <summary>
/// ѕолучение списка количеств участников
/// </summary>
public sealed class GetListKvnQuery : IRequest<KvnDto[]>
{
}

public sealed class GetListKvnQueryHandler : IRequestHandler<GetListKvnQuery, KvnDto[]>
{
    private readonly DataContext _dataContext;

    public GetListKvnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<KvnDto[]> Handle(GetListKvnQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.TheKvn
            .AsNoTracking()
            .Select(x => new KvnDto
            {
                IsnKvn = x.IsnKvn,
                IsnStudent = x.IsnStudent,
                IsnSubject = x.IsnSubject,
                ParticipantsCount = x.ParticipantsCount,
                KvnDate = x.KvnDate
            })
            .OrderByDescending(x => x.KvnDate)
            .ToArrayAsync(cancellationToken);
    }
}