using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Web.Features.University.Groups.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Groups.Commands;

/// <summary>
/// Создание группы
/// </summary>
public sealed class CreateGroupCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные группы
    /// </summary>
    [FromBody]
    [Required]
    public CreateGroupDto Group { get; init; }
}

public sealed class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IGroupService _groupService;

    public CreateGroupCommandHandler(
        DataContext dataContext,
        IGroupService groupService)
    {
        _dataContext = dataContext;
        _groupService = groupService;
    }

    public async Task<Guid> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        var group = new Group
        {
            IsnGroup = Guid.NewGuid(),
            Name = request.Group.Name
        };

        await _groupService.CreateOrUpdateGroupValidateAsync(_dataContext, group, cancellationToken);

        await _dataContext.Groups.AddAsync(group);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return group.IsnGroup;
    }
}
