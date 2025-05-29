using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Services.University;

public sealed class GroupService : IGroupService
{
    public async Task CreateOrUpdateGroupValidateAndThrowAsync(
        DataContext dataContext,
        Group group,
        CancellationToken cancellationToken = default)
    {
        if (await dataContext.Groups.AnyAsync(x => x.IsnGroup != group.IsnGroup && x.Name == group.Name, cancellationToken))
            throw new BusinessLogicException($"Группа с именем \"{group.Name}\" уже создана");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Group group,
        CancellationToken cancellationToken = default)
    {
        if (await dataContext.Students.AnyAsync(x => x.IsnGroup == group.IsnGroup, cancellationToken))
            throw new BusinessLogicException($"Группа не может быть удалена, т.к. к ней привязаны студенты");
    }
}
