using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Fitness.Member.DtoModels;

namespace Study.Lab3.Web.Features.Fitness.Member.Queries;

public class GetListMembersQuery : IRequest<MemberDto[]>
{
}

public sealed class GetListMembersQueryHandler : IRequestHandler<GetListMembersQuery, MemberDto[]>
{
    private readonly DataContext _dataContext;

    public GetListMembersQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MemberDto[]> Handle(GetListMembersQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Members
            .AsNoTracking()
            .Select(x => new MemberDto
            {
                IsnMember = x.IsnMember,
                SurName = x.SurName,
                Name = x.Name,
                PatronymicName = x.PatronymicName,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                DateOfBirth = x.DateOfBirth,
                MembershipType = x.MembershipType,
                MembershipStartDate = x.MembershipStartDate,
                MembershipEndDate = x.MembershipEndDate,
                IsActive = x.IsActive
            })
            .OrderBy(x => x.SurName)
            .ThenBy(x => x.Name)
            .ToArrayAsync(cancellationToken);
    }
}