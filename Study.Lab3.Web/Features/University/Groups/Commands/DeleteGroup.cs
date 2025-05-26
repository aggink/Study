using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Groups.Commands;
//Удаление группы
/// <summary>
/// Удаление группы
/// </summary>
public sealed class DeleteGroupCommand : IRequest
{
    /// <summary>
    /// Идентификатор группы
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnGroup { get; init; }
}

public sealed class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand>
{
    private readonly DataContext _dataContext;
    private readonly IGroupService _groupService;

    public DeleteGroupCommandHandler(
        DataContext dataContext,
        IGroupService groupService)
    {
        _dataContext = dataContext;
        _groupService = groupService;
    }

    public async Task Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await _dataContext.Groups.FirstOrDefaultAsync(x => x.IsnGroup == request.IsnGroup, cancellationToken)
            ?? throw new BusinessLogicException($"Группы с идентификатором \"{request.IsnGroup}\" не существует");

        await _groupService.CanDeleteAndThrowAsync(
            _dataContext, group, cancellationToken);

        _dataContext.Groups.Remove(group);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return;
    }
}
