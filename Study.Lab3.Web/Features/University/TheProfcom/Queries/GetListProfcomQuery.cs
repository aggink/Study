using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.TheProfcom.DtoModels;

namespace Study.Lab3.Web.Features.University.TheProfcom.Queries;

/// <summary>
/// Получение списка количеств участников
/// </summary>
public sealed class GetListProfcomQuery : IRequest<ProfcomDto[]>
{
}

public sealed class GetListProfcomQueryHandler : IRequestHandler<GetListProfcomQuery, ProfcomDto[]>
{
    private readonly DataContext _dataContext;

    public GetListProfcomQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ProfcomDto[]> Handle(GetListProfcomQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.TheProfcom
            .AsNoTracking()
            .Select(x => new ProfcomDto
            {
                IsnProfcom = x.IsnProfcom,
                IsnStudent = x.IsnStudent,
                IsnSubject = x.IsnSubject,
                ParticipantsCount = x.ParticipantsCount,
                ProfcomDate = x.ProfcomDate
            })
            .OrderByDescending(x => x.ProfcomDate)
            .ToArrayAsync(cancellationToken);
    }
}