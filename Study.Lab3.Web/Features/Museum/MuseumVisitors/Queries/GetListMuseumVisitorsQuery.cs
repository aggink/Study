using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Museum.MuseumVisitors.DtoModels;

namespace Study.Lab3.Web.Features.Museum.MuseumVisitors.Queries;

/// <summary>
/// Получение списка посетителей музея
/// </summary>
public sealed class GetListMuseumVisitorsQuery : IRequest<MuseumVisitorDto[]>
{
}

public sealed class GetListMuseumVisitorsQueryHandler : IRequestHandler<GetListMuseumVisitorsQuery, MuseumVisitorDto[]>
{
    private readonly DataContext _dataContext;

    public GetListMuseumVisitorsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MuseumVisitorDto[]> Handle(GetListMuseumVisitorsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.MuseumVisitors
            .AsNoTracking()
            .Select(x => new MuseumVisitorDto
            {
                IsnMuseumVisitor = x.IsnMuseumVisitor,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Phone = x.Phone,
                DateOfBirth = x.DateOfBirth,
                VisitDate = x.VisitDate,
                TicketType = x.TicketType,
                TicketPrice = x.TicketPrice,
                IsMember = x.IsMember,
                MembershipNumber = x.MembershipNumber
            })
            .OrderBy(x => x.LastName)
            .ThenBy(x => x.FirstName)
            .ToArrayAsync(cancellationToken);
    }
}
