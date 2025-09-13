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

public class InternService : IInternService
{
    public async Task CreateOrUpdateGroupValidateAndThrowAsync(
    DataContext dataContext,
    Intern intern,
    CancellationToken cancellationToken = default)
    {
        if (await dataContext.Interns.AnyAsync(x => x.IsnIntern != intern.IsnIntern && x.Name == intern.Name, cancellationToken))
            throw new BusinessLogicException($"Стажер с именем \"{intern.Name}\" уже создан");
    }
}
