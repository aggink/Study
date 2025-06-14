using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Pingpongclub.DtoModels;

namespace Study.Lab3.Web.Features.University.Pingpongclub.Queries;

/// <summary>
/// ѕолучение списка количеств участников
/// </summary>
public sealed class GetListPingpongclubQuery : IRequest<PingpongclubDto[]>
{
}

public sealed class GetListPingpongclubQueryHandler : IRequestHandler<GetListPingpongclubQuery, PingpongclubDto[]>
{
    private readonly DataContext _dataContext;

    public GetListPingpongclubQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PingpongclubDto[]> Handle(GetListPingpongclubQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Pingpongclub
            .AsNoTracking()
            .Select(x => new PingpongclubDto
            {
                IsnPingpongclub = x.IsnPingpongclub,
                IsnStudent = x.IsnStudent,
                IsnSubject = x.IsnSubject,
                ParticipantsCount = x.ParticipantsCount,
                PingpongclubDate = x.PingpongclubDate
            })
            .OrderByDescending(x => x.PingpongclubDate)
            .ToArrayAsync(cancellationToken);
    }
}