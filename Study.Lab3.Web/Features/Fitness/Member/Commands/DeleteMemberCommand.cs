using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Fitness;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.Fitness.Member.Commands;

/// <summary>
/// Удаление участника
/// </summary>
public sealed class DeleteMemberCommand : IRequest
{
    /// <summary>
    /// Идентификатор участника
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnMember { get; init; }
}

public sealed class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommand>
{
    private readonly DataContext _dataContext;
    private readonly IFitnessMemberService _memberService;

    public DeleteMemberCommandHandler(
        DataContext dataContext,
        IFitnessMemberService memberService)
    {
        _dataContext = dataContext;
        _memberService = memberService;
    }

    public async Task Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
    {
        var member = await _dataContext.Members
                         .FirstOrDefaultAsync(x => x.IsnMember == request.IsnMember, cancellationToken)
                     ?? throw new BusinessLogicException($"Участник с идентификатором \"{request.IsnMember}\" не существует");

        await _memberService.CanDeleteAndThrowAsync(
            _dataContext, member, cancellationToken);

        _dataContext.Members.Remove(member);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}