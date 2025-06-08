using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Fitness;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Fitness.Member.DtoModels;

namespace Study.Lab3.Web.Features.Fitness.Member.Commands;

public class UpdateMemberCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные участника
    /// </summary>
    [Required]
    [FromBody]
    public UpdateMemberDto Member { get; init; }
}

public sealed class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IFitnessMemberService _memberService;

    public UpdateMemberCommandHandler(
        DataContext dataContext,
        IFitnessMemberService memberService)
    {
        _dataContext = dataContext;
        _memberService = memberService;
    }

    public async Task<Guid> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
    {
        var member = await _dataContext.Members
                         .FirstOrDefaultAsync(x => x.IsnMember == request.Member.IsnMember, cancellationToken)
                     ?? throw new BusinessLogicException($"Участник с идентификатором \"{request.Member.IsnMember}\" не существует");

        member.SurName = request.Member.SurName;
        member.Name = request.Member.Name;
        member.PatronymicName = request.Member.PatronymicName;
        member.PhoneNumber = request.Member.PhoneNumber;
        member.Email = request.Member.Email;
        member.DateOfBirth = request.Member.DateOfBirth;
        member.MembershipType = request.Member.MembershipType;
        member.MembershipStartDate = request.Member.MembershipStartDate;
        member.MembershipEndDate = request.Member.MembershipEndDate;
        member.IsActive = request.Member.IsActive;

        await _memberService.CreateOrUpdateMemberValidateAndThrowAsync(
            _dataContext, member, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return member.IsnMember;
    }
}