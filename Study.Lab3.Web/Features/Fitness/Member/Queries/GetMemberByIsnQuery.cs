using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Fitness.Member.DtoModels;

namespace Study.Lab3.Web.Features.Fitness.Member.Queries;

/// <summary>
/// Получение участника по идентификатору
/// </summary>
public sealed class GetMemberByIsnQuery : IRequest<MemberDto>
{
    /// <summary>
    /// Идентификатор участника
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnMember { get; init; }
}

public sealed class GetMemberByIsnQueryHandler : IRequestHandler<GetMemberByIsnQuery, MemberDto>
{
    private readonly DataContext _dataContext;

    public GetMemberByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MemberDto> Handle(GetMemberByIsnQuery request, CancellationToken cancellationToken)
    {
        var member = await _dataContext.Members
                         .AsNoTracking()
                         .FirstOrDefaultAsync(x => x.IsnMember == request.IsnMember, cancellationToken)
                     ?? throw new BusinessLogicException($"Участник с идентификатором \"{request.IsnMember}\" не существует");

        return new MemberDto
        {
            IsnMember = member.IsnMember,
            SurName = member.SurName,
            Name = member.Name,
            PatronymicName = member.PatronymicName,
            PhoneNumber = member.PhoneNumber,
            Email = member.Email,
            DateOfBirth = member.DateOfBirth,
            MembershipType = member.MembershipType,
            MembershipStartDate = member.MembershipStartDate,
            MembershipEndDate = member.MembershipEndDate,
            IsActive = member.IsActive
        };
    }
}