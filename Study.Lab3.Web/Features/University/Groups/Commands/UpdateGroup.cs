using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Groups.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Groups.Commands;

/// <summary>
/// Редактирование группы
/// </summary>
public sealed class UpdateGroupCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные группы
    /// </summary>
    [Required]
    [FromBody]
    public UpdateGroupDto Group { get; init; }
}

public sealed class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IGroupService _groupService;

    public UpdateGroupCommandHandler(
        DataContext dataContext,
        IGroupService groupService)
    {
        _dataContext = dataContext;
        _groupService = groupService;
    }

    public async Task<Guid> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await _dataContext.Groups.FirstOrDefaultAsync(x => x.IsnGroup == request.Group.IsnGroup, cancellationToken)
            ?? throw new BusinessLogicException($"Группы с идентификатором \"{request.Group.IsnGroup}\" не существует");

        group.Name = request.Group.Name;

        await _groupService.CreateOrUpdateGroupValidateAndThrowAsync(
            _dataContext, group, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return group.IsnGroup;
    }
}
