using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.PoliceDepartament;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.PoliceDepartament;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab3.Logic.Services.PoliceDepartament;

public class OfficerService : IOfficerService
{
    public async Task CreateOrUpdateGroupValidateAndThrowAsync(
    DataContext dataContext,
    Officer officer,
    CancellationToken cancellationToken = default)
    {
        if (await dataContext.Officers.AnyAsync(x => x.IsnOfficer != officer.IsnOfficer && x.Name == officer.Name, cancellationToken))
            throw new BusinessLogicException($"Офицер с именем \"{officer.Name}\" уже создан");
    }
}
