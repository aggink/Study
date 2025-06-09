using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Fitness;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Fitness;
using Study.Lab3.Web.Features.Fitness.Member.DtoModels;

namespace Study.Lab3.Web.Features.Fitness.Member.Commands;

/// <summary>
/// Создание участника
/// </summary>
public sealed class CreateMemberCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные участника
    /// </summary>
    [Required]
    [FromBody]
    public CreateMemberDto Member { get; init; }
}

public sealed class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IFitnessMemberService _memberService;

    public CreateMemberCommandHandler(
        DataContext dataContext,
        IFitnessMemberService memberService)
    {
        _dataContext = dataContext;
        _memberService = memberService;
    }

    public async Task<Guid> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
    {
        var member = new FitnessMember
        {
            IsnMember = Guid.NewGuid(),
            SurName = request.Member.SurName,
            Name = request.Member.Name,
            PatronymicName = request.Member.PatronymicName,
            PhoneNumber = request.Member.PhoneNumber,
            Email = request.Member.Email,
            DateOfBirth = request.Member.DateOfBirth,
            MembershipType = request.Member.MembershipType,
            MembershipStartDate = request.Member.MembershipStartDate,
            MembershipEndDate = request.Member.MembershipEndDate,
            IsActive = request.Member.IsActive
        };

        await _memberService.CreateOrUpdateMemberValidateAndThrowAsync(
            _dataContext, member, cancellationToken);

        await _dataContext.Members.AddAsync(member, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return member.IsnMember;
    }
}