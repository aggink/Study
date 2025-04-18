using CoreLib.Common.Extensions;
using Lab3.Logic.Interfaces.Services.University;
using Lab3.Storage.Database;
using Lab3.Storage.Models.University;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Logic.Services.University
{
    public class GroupService : IGroupService
    {
        public async Task CreateOrUpdateGroupValidateAsync(DataContext dataContext, Group group, CancellationToken cancellationToken)
        {
            if (await dataContext.Groups.AnyAsync(x => x.IsnGroup != group.IsnGroup && x.Name == group.Name))
                throw new BusinessLogicException($"Группа с именем \"{group.Name}\" уже создана");
        }

        public async Task CanDeleteAsync(DataContext dataContext, Group group, CancellationToken cancellationToken)
        {
            if (await dataContext.Students.AnyAsync(x => x.IsnGroup == group.IsnGroup, cancellationToken))
                throw new BusinessLogicException($"Группа не может быть удалена, т.к. к ней привязаны студенты");
        }
    }
}
